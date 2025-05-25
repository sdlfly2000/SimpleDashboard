using EasyNetQ;

namespace MessageQueue.RabbitMQ.MessageQueue
{
    public interface IAMQPConsumer
    {
        public Task OnMessage(ReadOnlyMemory<byte> body, MessageProperties properties, MessageReceivedInfo info);
    }
}
