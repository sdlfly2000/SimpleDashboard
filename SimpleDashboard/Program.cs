using Common.Core.DependencyInjection;
using Infra.Database.MySQL;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddMySQLDatabase(builder.Configuration.GetConnectionString("SimpleDashboard")!);

builder.Services.AddDbContext<SimpleDashboardContext>(
                options => options.UseMySql(
                    builder.Configuration.GetConnectionString("SimpleDashboard"),
                    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("SimpleDashboard")),
                    b => b.MigrationsAssembly("Infra.Database.MySQL")));

//builder.Services.RegisterDomain(
//    "SimpleDashboard",
//    "Application.Services",
//    "Domain.Serivces",
//    "Infra.Database.MySQL");

builder.Services.RegisterDomain(
    "SimpleDashboard",
    "Infra.Database.MySQL");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
