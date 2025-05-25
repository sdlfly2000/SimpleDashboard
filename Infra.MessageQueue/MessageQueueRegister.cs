using EasyNetQ;
using EasyNetQ.Topology;
using MessageQueue.RabbitMQ.MessageQueue;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MessageQueue.RabbitMQ
{
    public class MessageQueueRegister
    {
        public static void Register(IEnumerable<IAMQPConsumer> consumers, IAdvancedBus advancedBus, params string[] domains)
        {
            var asms = domains.Select(domain => Assembly.Load(domain)).ToList();
            var impls = asms.SelectMany(asm => asm.GetExportedTypes().Where(t => !t.IsInterface).ToList()).ToList();

            foreach (var impl in impls)
            {
                var consumer = impl.GetCustomAttribute(typeof(AMQPConsumerAttribute));
                if (consumer != null)
                {
                    var consumerTypeName = (consumer as AMQPConsumerAttribute).ConsumerTypeName;
                    var messageTypeName = (consumer as AMQPConsumerAttribute).MessageTypeName;
                    var routingKeys = (consumer as AMQPConsumerAttribute).RoutingKeys;

                    var queueName = $"{messageTypeName.Name}-{consumerTypeName.Name}-({string.Join('.', routingKeys)})";
                    var queue = advancedBus.QueueDeclare(queueName);
                    var exchange = advancedBus.ExchangeDeclare(messageTypeName.Name, ExchangeType.Topic);

                    var poisonQueue = advancedBus.QueueDeclare($"{messageTypeName.Name}.poison");
                    var poisonExchange = advancedBus.ExchangeDeclare($"{messageTypeName.Name}.poison", ExchangeType.Topic);
                    foreach (var routingKey in routingKeys)
                    {
                        advancedBus.Bind(exchange, queue, routingKey);
                    }

                    advancedBus.Bind(poisonExchange, poisonQueue, "");

                    var consumerService = consumers.FirstOrDefault(c => c.GetType() == consumerTypeName);
                    advancedBus.Consume(queue, consumerService.OnMessage);
                }
            }
        }
    }
}
