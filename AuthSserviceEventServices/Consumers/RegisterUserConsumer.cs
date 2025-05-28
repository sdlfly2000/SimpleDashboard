using Application.Services.User;
using Application.User;
using AuthServiceEventServices.Models;
using Common.Core.DependencyInjection;
using EasyNetQ;
using MessageQueue.RabbitMQ.MessageQueue;

namespace AuthServiceEventServices.Consumers
{
    [AMQPConsumer(ConsumerTypeName = typeof(RegisterUserConsumer), MessageTypeName = typeof(UserMessage), RoutingKeys =["register"])]
    [ServiceLocate(typeof(IAMQPConsumer), ServiceType.Scoped)]
    public class RegisterUserConsumer : ConsumerBase<UserMessage>
    {
        private readonly ILogger<RegisterUserConsumer> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public RegisterUserConsumer(
            ILogger<RegisterUserConsumer> logger,
            IServiceScopeFactory scopeFactory,
            IBus bus) : base(bus)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        public async override Task<bool> ProcessMessage(IMessage<UserMessage> message, MessageProperties properties, MessageReceivedInfo info)
        {
            _logger.LogInformation($"{nameof(RegisterUserConsumer)}: receievd {nameof(UserMessage)} with id:{{amqpMessageId}}", message.Body.Id);

            var request = new UserRegisterRequest
            {
                UserId = message.Body.UserId,
                Name = message.Body.UserName
            };

            using var scope = _scopeFactory.CreateScope();

            var service = scope.ServiceProvider.GetRequiredService<UserService>();

            var response = await service.Register(request);

            return response.IsSuccess;
        }
    }
}
