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
        public CreateBlogResponse CreateBlog(Blog.Blog blog)
        {
            return _client.CreateBlog(new CreateBlogRequest()
            {
                Blog = blog
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

        public UpdateBlogByIdResponse UpdateBlogById(Blog.Blog blog)
        {
            try
            {
                return _client.UpdateBlogById(new UpdateBlogByIdRequest() { Blog = blog });
            }
            catch (RpcException ex)
            {
                Console.WriteLine(ex.Status.Detail);
                throw;
            }
        }

        public DeleteBlogByIdResponse DeleteBlogById(string id)
        {
            try
            {
                return _client.DeleteBlogById(new DeleteBlogByIdRequest() { Id = id });
            }
            catch (RpcException ex)
            {
                Console.WriteLine(ex.Status.Detail);
                throw;
            }

        }
    }
}
