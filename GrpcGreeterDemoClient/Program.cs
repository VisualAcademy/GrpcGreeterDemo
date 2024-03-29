﻿using FeatureApp;
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

            //[1]
            var client = GrpcClient.Create<Greeter.GreeterClient>(httpClient);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "빌드2019" });
            Console.WriteLine("인사: " + reply.Message);
            
            //[2]
            var client2 = GrpcClient.Create<MessageType.MessageTypeClient>(httpClient);
            var reply2 = await client2.SayMessageAsync(new MessageRequest { Name = "빌드 서울" });
            Console.WriteLine("메시지: " + reply2.Message);

            //[3]
            var client3 = GrpcClient.Create<FeatureType.FeatureTypeClient>(httpClient);
            var reply3 = await client3.GetAllAsync(new FeatureRequest { PageNumber = "1" });

            foreach (var item in reply3.Features)
            {
                Console.WriteLine($"{item.Id} - {item.Title} - {item.Created}");
            }

            Console.ReadKey();
        }
    }
}
