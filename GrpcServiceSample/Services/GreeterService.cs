using System.Threading.Tasks;
using Grpc.Core;
using GrpcServiceSample.Core;
using Microsoft.Extensions.Logging;

namespace GrpcServiceSample.Services
{
    public class GreeterService : Hello.HelloBase
    {
        private readonly ILogger<GreeterService> _logger;

        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloWorldResponse> HelloWorld(HelloWorldRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloWorldResponse()
            {
                Message = "Hello World! " + request.Name
            });
        }
    }
}