namespace MessageQueue.RabbitMQ.Marks;

public abstract class BaseMessage
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
