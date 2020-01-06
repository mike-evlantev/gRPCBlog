using Blog;
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
            var doc = new BsonDocument()
            {
                { "authorId", request.Blog.AuthorId },
                { "title", request.Blog.Title},
                { "content", request.Blog.Content }
            };

            _blogs.InsertOne(doc);
            var blog = BsonSerializer.Deserialize<Blog.Blog>(doc);
            return Task.FromResult(new CreateBlogResponse()
            {
                Blog = blog
            });
        }

        public override async Task GetAllBlogs(GetAllBlogsRequest request, IServerStreamWriter<GetAllBlogsResponse> responseStream, ServerCallContext context)
        {
            var filter = new FilterDefinitionBuilder<BsonDocument>().Empty;
            var result = _blogs.Find(filter);
            foreach (var doc in result.ToList())
            {
                await responseStream.WriteAsync(new GetAllBlogsResponse()
                {
                    //Blog = new Blog.Blog()
                    //{
                    //    Id = 
                    //}
                    Blog = BsonSerializer.Deserialize<Blog.Blog>(doc)
                });
            }
        }

        public override Task<GetBlogByIdResponse> GetBlogById(GetBlogByIdRequest request, ServerCallContext context)
        {
            var id = request.Id;
            var filter = new FilterDefinitionBuilder<BsonDocument>().Eq("_id", new ObjectId(id));
            var result = _blogs.Find(filter).FirstOrDefault();
            if (result == null)
                throw new RpcException(new Status(StatusCode.NotFound, $"Blog {id} not found"));

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
