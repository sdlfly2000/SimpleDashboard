using AuthServiceEventServices.Models;
using Common.Core.DependencyInjection;
using EasyNetQ;
using MessageQueue.RabbitMQ.MessageQueue;
using Newtonsoft.Json;

namespace AuthServiceEventServices.Consumers
{
    [AMQPConsumer(ConsumerTypeName = typeof(RegisterUserConsumer), MessageTypeName = typeof(UserMessage), RoutingKeys =["register"])]
    [ServiceLocate(default, ServiceType.Singleton)]
    public class RegisterUserConsumer : IAMQPConsumer
    {
        private readonly ILogger<RegisterUserConsumer> _logger;

        public RegisterUserConsumer(ILogger<RegisterUserConsumer> logger)
        {
            _logger = logger;
        }

        public async Task ProcessMessage(ReadOnlyMemory<byte> body, MessageProperties properties, MessageReceivedInfo info)
        {
            var messagePayload = JsonConvert.DeserializeObject<UserMessage>(body.ToString());

        }
    }
}
