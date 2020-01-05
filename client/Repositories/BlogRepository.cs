using Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Repositories
{
    public class BlogRepository
    {
        public CreateBlogResponse CreateBlog(BlogService.BlogServiceClient client)
        {
            return client.CreateBlog(new CreateBlogRequest()
            {
                Blog = new Blog.Blog()
                {
                    AuthorId = "Mike",
                    Title = "First Blog Post!",
                    Content = "Hello world!"
                }
            });
        }
    }
}
