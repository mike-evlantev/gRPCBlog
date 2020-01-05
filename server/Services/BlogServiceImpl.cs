﻿using Blog;
using Grpc.Core;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Blog.BlogService;

namespace server.Services
{
    public class BlogServiceImpl : BlogServiceBase
    {
        const string Blogs = "blogs";

        private static IMongoDatabase _db;
        private static IMongoCollection<BsonDocument> _blogs;
        public BlogServiceImpl(IMongoDatabase db)
        {
            _db = db;
            _blogs = db.GetCollection<BsonDocument>(Blogs);
        }
        public override Task<CreateBlogResponse> CreateBlog(CreateBlogRequest request, ServerCallContext context)
        {

            var blog = request.Blog;
            BsonDocument doc = new BsonDocument("authorId", blog.AuthorId)
                                            .Add("title", blog.Title)
                                            .Add("content", blog.Content);

            _blogs.InsertOne(doc);
            blog.Id = doc.GetValue("_id").ToString();
            return Task.FromResult(new CreateBlogResponse()
            {
                Blog = blog
            });
        }

        public override Task<GetBlogByIdResponse> GetBlogById(GetBlogByIdRequest request, ServerCallContext context)
        {
            var id = request.Id;
            var filter = new FilterDefinitionBuilder<BsonDocument>().Eq("_id", new ObjectId(id));
            var result = _blogs.Find(filter).FirstOrDefault();
            if (result == null)
                throw new RpcException(new Status(StatusCode.NotFound, $"Blog {id} not found"));

            result.Remove("_id");
            var blog = BsonSerializer.Deserialize<Blog.Blog>(result);

            return Task.FromResult(new GetBlogByIdResponse() { Blog = blog });
        }

        public override Task<UpdateBlogByIdResponse> UpdateBlogById(UpdateBlogByIdRequest request, ServerCallContext context)
        {
            var id = request.Blog.Id;
            var filter = new FilterDefinitionBuilder<BsonDocument>().Eq("_id", new ObjectId(id));
            var result = _blogs.Find(filter).FirstOrDefault();
            if (result == null)
                throw new RpcException(new Status(StatusCode.NotFound, $"Blog {id} not found"));

            var doc = new BsonDocument();
            using (var writer = new BsonDocumentWriter(doc))
                BsonSerializer.Serialize(writer, request.Blog);

            doc.Remove("_id");
            _blogs.ReplaceOne(filter, doc);

            var blog = BsonSerializer.Deserialize<Blog.Blog>(doc);
            return Task.FromResult(new UpdateBlogByIdResponse() { Blog = blog });

        }

        public override Task<DeleteBlogByIdResponse> DeleteBlogById(DeleteBlogByIdRequest request, ServerCallContext context)
        {
            var id = request.Id;
            var filter = new FilterDefinitionBuilder<BsonDocument>().Eq("_id", new ObjectId(id));
            var result = _blogs.DeleteOne(filter);
            if (result.DeletedCount == 0)
                throw new RpcException(new Status(StatusCode.NotFound, $"Blog {id} not found"));

            return Task.FromResult(new DeleteBlogByIdResponse() { Id = id });
        }
    }
}
