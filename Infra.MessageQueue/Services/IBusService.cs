using MessageQueue.RabbitMQ.Marks;

namespace MessageQueue.RabbitMQ.Services
{
    public interface IBusService
    {
        public Task publish<TMessage>(TMessage message, string routingKey) where TMessage : BaseMessage;
    }
}
