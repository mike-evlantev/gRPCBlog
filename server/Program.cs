using Blog;
using dotenv.net;
using Grpc.Core;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using server.Services;
using System;
using System.IO;

namespace server
{
    class Program
    {
        const int Port = 50051;
        const string MongoUri = "MONGO_URI";
        const string Db = "grpcblog";
        const string EnvPath = "C:/Source/gRPCBlog/.env";

        static void Main(string[] args)
        {
            // Enable .env variables
            DotEnv.Config(true, EnvPath);

            // Connect to MongoDB            
            var client = new MongoClient(Environment.GetEnvironmentVariable(MongoUri));
            var db = client.GetDatabase(Db);
            Console.WriteLine("Conneted to DB: " + db.DatabaseNamespace);

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
