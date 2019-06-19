using System.Threading.Tasks;
using FeatureApp;
using Grpc.Core;

namespace GrpcGreeterDemo
{
    //public class FeatureService : MessageType.MessageTypeBase
    public class FeatureService : FeatureType.FeatureTypeBase
    {
        public override Task<FeatureReply> GetAll(FeatureRequest request, ServerCallContext context)
        {
            FeatureReply reply = new FeatureReply();
            reply.Features.Add(new FeatureEntity { Id = 1, Title = "ASP.NET", Created = "1234" });
            reply.Features.Add(new FeatureEntity { Id = 2, Title = "Blazor", Created = "1234" });
            reply.Features.Add(new FeatureEntity { Id = 3, Title = "C#", Created = "1234" });

            return Task.FromResult(reply); 
        }
    }
}
