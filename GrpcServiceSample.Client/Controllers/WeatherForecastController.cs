using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcServiceSample.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GrpcServiceSample.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly Hello.HelloClient _client;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
                                         Hello.HelloClient client)
        {
            _logger = logger;
            _client = client;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var response = await _client.HelloWorldAsync(new HelloWorldRequest
            {
                Name = "Test"
            });

            return response.Message;
        }
    }
}