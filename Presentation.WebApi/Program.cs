using Common.Core.Authentication;
using Common.Core.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SimpleDashboard.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JWTOptions>(builder.Configuration.GetSection("JWT"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtCusScheme(builder.Configuration.GetSection("JWT").Get<JWTOptions>()!);

builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowPolicy", builder => builder.AllowAnyOrigin().AllowAnyHeader());
});
builder.Services.AddMemoryCache();
builder.Services.AddMySQLDatabase(builder.Configuration.GetConnectionString("SimpleDashboard")!);
builder.Services.RegisterDomain("Application.Services", "Domain.Services", "Infra.Database.MySQL");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
