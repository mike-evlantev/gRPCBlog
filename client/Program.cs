using Blog;
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

            var client = new BlogService.BlogServiceClient(channel);
            var response = client.CreateBlog(new CreateBlogRequest()
            {
                Blog = new Blog.Blog()
                { 
                    AuthorId = "Mike",
                    Title = "First Blog Post!",
                    Content = "Hello world!"
                }
            });

            Console.WriteLine($"Blog {response.Blog.Id} created!");

            channel.ShutdownAsync().Wait();
            Console.ReadKey();
        }
    }
}
