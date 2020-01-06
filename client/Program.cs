using Blog;
using client.Repositories;
using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        const string target = "127.0.0.1:50051";

        static async Task Main(string[] args)
        {
            
            Channel channel = new Channel(target, ChannelCredentials.Insecure);
            await channel.ConnectAsync().ContinueWith((task) =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                    Console.WriteLine("Client connected successfully");

            });

            BlogRepository blogRepository = new BlogRepository(new BlogService.BlogServiceClient(channel));

            // Create Blog
            var newBlog = new Blog.Blog()
            {
                AuthorId = "Mike",
                Title = "First Blog Post!",
                Content = "Hello world!"
            };
            var createResponse = blogRepository.CreateBlog(newBlog);
            Console.WriteLine($"Blog {createResponse.Blog.Id} created!");

            // Get All Blogs
            var getAllResponse = blogRepository.GetAllBlogs(new GetAllBlogsRequest());
            while (await getAllResponse.ResponseStream.MoveNext())
            {
                Console.WriteLine(getAllResponse.ResponseStream.Current.Blog.ToString());
            }

            // Get Blog By Id
            var getResponse = blogRepository.GetBlogById(createResponse.Blog.Id);
            Console.WriteLine(getResponse.Blog.ToString());

            // Update Blog By Id
            var blogToUpdate = new Blog.Blog()
            {
                Id = createResponse.Blog.Id,
                AuthorId = "Aladdin",
                Title = "This is an updated title",
                Content = "This is updated content"
            };
            var updateResponse = blogRepository.UpdateBlogById(blogToUpdate);
            Console.WriteLine(updateResponse.Blog.ToString());

            // Delete Blog By Id
            var deleteResponse = blogRepository.DeleteBlogById(updateResponse.Blog.Id);
            Console.WriteLine($"Blog {deleteResponse.Id} deleted!");

            channel.ShutdownAsync().Wait();
            Console.ReadKey();
        }
    }
}
