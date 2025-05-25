using EasyNetQ;
using MessageQueue.RabbitMQ;
using MessageQueue.RabbitMQ.MessageQueue;

namespace AuthServiceEventServices
{
    public class Worker : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public Worker(ILogger<Worker> logger, IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _scopeFactory.CreateScope();
            var consumers = scope.ServiceProvider.GetServices<IAMQPConsumer>();
            var advancedBus = scope.ServiceProvider.GetRequiredService<IBus>().Advanced;

            MessageQueueRegister.Register(
                consumers,
                advancedBus,
                "AuthServiceEventServices");
        }
    }
}
