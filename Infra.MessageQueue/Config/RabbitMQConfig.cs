﻿namespace MessageQueue.RabbitMQ.Config;

public class RabbitMQConfig
{
    public string Host { get; set; }
    public ushort Port { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string VirtualHost { get; set; }
}
