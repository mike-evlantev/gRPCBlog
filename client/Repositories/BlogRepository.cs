using Blog;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Repositories
{
    public class BlogRepository
    {
        private static BlogService.BlogServiceClient _client;
        public BlogRepository(BlogService.BlogServiceClient client)
        {
            _client = client;
        }
        public CreateBlogResponse CreateBlog()
        {
            return _client.CreateBlog(new CreateBlogRequest()
            {
                Blog = new Blog.Blog()
                {
                    AuthorId = "Mike",
                    Title = "First Blog Post!",
                    Content = "Hello world!"
                }
            });
        }

        public GetBlogByIdResponse GetBlogById(string id)
        {
            try
            {
                return _client.GetBlogById(new GetBlogByIdRequest() { Id = id });
            }
            catch (RpcException ex)
            {
                Console.WriteLine(ex.Status.Detail);
                throw;
            }
            
        }
    }
}
