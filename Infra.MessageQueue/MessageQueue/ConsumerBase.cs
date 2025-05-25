using EasyNetQ;
using EasyNetQ.Topology;
using System.Text;

namespace MessageQueue.RabbitMQ.MessageQueue
{
    public class ConsumerBase<T> : IAMQPConsumer
    {
        private readonly IAdvancedBus _bus;

        public ConsumerBase(IBus eventBus)
        {
            _bus = eventBus.Advanced;
        }

        public async Task OnMessage(ReadOnlyMemory<byte> body, MessageProperties properties, MessageReceivedInfo info)
        {
            var messageString = Encoding.UTF8.GetString(body.ToArray());
            var messagePayload = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(messageString);
            var message = new Message<T>(messagePayload, properties);
            var result = await ProcessMessage(message, properties, info);

            if (!result)
            {
                var poisonExchange = new Exchange($"{typeof(T).Name}.poison", ExchangeType.Topic);
                var poisonMessage = new Message<T>(messagePayload, properties);
                await _bus.PublishAsync(poisonExchange,"", false, poisonMessage);
            }
        }

        public virtual async Task<bool> ProcessMessage(IMessage<T> body, MessageProperties properties, MessageReceivedInfo info)
        {
            return true;
        }
    }
}
