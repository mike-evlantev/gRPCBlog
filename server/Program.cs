using Blog;
using dotenv.net;
using Grpc.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using server.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    class Program
    {
        const int Port = 50051;
        const string MongoUri = "MONGO_URI";
        const string Db = "grpcblog";

        static void Main(string[] args)
        {
            // Connect to MongoDB
            DotEnv.Config();
            var client = new MongoClient(Environment.GetEnvironmentVariable(MongoUri));
            var db = client.GetDatabase(Db);

            Server server = null;
            try
            {
                server = new Server()
                {
                    Services = { BlogService.BindService(new BlogServiceImpl(db)) },
                    Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
                };

                server.Start();
                Console.WriteLine("Server listening on port: " + Port);
                Console.ReadLine();
            }
            catch (IOException ex)
            {
                Console.WriteLine("Server failed to start: ", ex.Message);
                throw;
            }
            finally
            {
                if (server != null)
                    server.ShutdownAsync().Wait();
            }
        }
    }
}
