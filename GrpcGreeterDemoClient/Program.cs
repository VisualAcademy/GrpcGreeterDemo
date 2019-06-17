using Grpc.Net.Client;
using GrpcGreeterDemo;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GrpcGreeterDemoClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:50051");
            var client = GrpcClient.Create<Greeter.GreeterClient>(httpClient);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "빌드2019" });
            Console.WriteLine("인사: " + reply.Message);
            Console.ReadKey();
        }
    }
}
