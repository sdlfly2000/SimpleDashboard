using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Database.SQLServer.Test
{
    public class DbContextFactory
    {
        public static TDbContext CreateFake<TDbContext>() where TDbContext : DbContext
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<TDbContext>();
            dbContextOptionsBuilder.UseInMemoryDatabase("SimpleDashboard");

            var dbContextOptions = dbContextOptionsBuilder.Options;
            var dbContext = Activator.CreateInstance(typeof(TDbContext), dbContextOptions);

            return dbContext as TDbContext;
        }

        public static TDbContext Create<TDbContext>() where TDbContext : DbContext
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            var configuration = configurationBuilder.Build();

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<TDbContext>();
            dbContextOptionsBuilder.UseSqlServer(configuration.GetConnectionString("SimpleDashboard"));

            var dbContextOptions = dbContextOptionsBuilder.Options;
            var dbContext = Activator.CreateInstance(typeof(TDbContext), dbContextOptions);

            return dbContext as TDbContext;
        }
    }
}
