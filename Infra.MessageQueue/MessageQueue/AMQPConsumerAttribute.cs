namespace MessageQueue.RabbitMQ.MessageQueue
{
    public class AMQPConsumerAttribute : Attribute
    {
        public Type ConsumerTypeName { get; set; }
        public Type MessageTypeName { get; set; }
        public string[] RoutingKeys { get; set; }
    }
}
