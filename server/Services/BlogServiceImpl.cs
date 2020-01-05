using Blog;
using Grpc.Core;
using MongoDB.Bson;
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
    }
}
