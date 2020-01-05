using Blog;
using client.Repositories;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            //var createdBlog = blogRepository.CreateBlog();
            //Console.WriteLine($"Blog {createdBlog.Blog.Id} created!");

            // Get Blog By Id
            var response = blogRepository.GetBlogById("5e116e0c3136041aec3e21a2");
            Console.WriteLine(response.Blog.ToString());
            


            channel.ShutdownAsync().Wait();
            Console.ReadKey();
        }
    }
}
