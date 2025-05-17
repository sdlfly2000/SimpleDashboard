using AuthServiceEventServices;
using Common.Core.DependencyInjection;
using MessageQueue.RabbitMQ.Extentions;
using Serilog;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddHostedService<Worker>();
        builder.Services.AddSerilog(
            (configure) => configure.ReadFrom.Configuration(builder.Configuration));
        //builder.Services.RegisterEasyNetQ();
        builder.Services.AddRabbitMQBus(builder.Configuration);
        builder.Services.AddMemoryCache();
        builder.Services.RegisterDomain("AuthServiceEventServices", "MessageQueue.RabbitMQ");

        var host = builder.Build();

        host.Run();
    }
}