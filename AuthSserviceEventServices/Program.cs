using AuthServiceEventServices;
using Common.Core.DependencyInjection;
using MessageQueue.RabbitMQ.Extentions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SimpleDashboard.Extentions;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddSerilog(
    (configure) => configure.ReadFrom.Configuration(builder.Configuration));
builder.Services.AddSQLServerDatabase(builder.Configuration.GetConnectionString("SimpleDashboard"));
builder.Services.RegisterDomain("AuthServiceEventServices", "Application.Services", "Domain.Services", "Infra.Database.SQLServer", "SimpleDashboard.Common", "MessageQueue.RabbitMQ");
builder.Services.AddRabbitMQBus(builder.Configuration);

var host = builder.Build();

host.Run();
