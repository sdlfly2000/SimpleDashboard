using MessageQueue.RabbitMQ.Marks;

namespace AuthServiceEventServices.Models;

public class UserMessage : BaseMessage
{        
    public Guid UserId { get; set; }
    public string UserName { get; set; }
}
