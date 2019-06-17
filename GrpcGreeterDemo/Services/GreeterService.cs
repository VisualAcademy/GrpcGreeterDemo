using System.Threading.Tasks;
using Grpc.Core;

namespace GrpcGreeterDemo
{
    public class GreeterService : Greeter.GreeterBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "�ȳ��ϼ���. " + request.Name
            });
        }
    }
}
