using EasyNetQ;

namespace MessageQueue.RabbitMQ.MessageQueue
{
    public interface IAMQPConsumer
    {
        public Task ProcessMessage(ReadOnlyMemory<byte> body, MessageProperties properties, MessageReceivedInfo info);
    }
}
