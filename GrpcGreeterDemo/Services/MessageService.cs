using System.Threading.Tasks;
using Grpc.Core;

namespace GrpcGreeterDemo
{
    public class MessageService : MessageType.MessageTypeBase
    {
        public override Task<MessageReply> SayMessage(MessageRequest request, ServerCallContext context)
        {
            return Task.FromResult(new MessageReply
            {
                Message = "æ»≥Á«œººø‰. " + request.Name
            });
        }
    }
}
