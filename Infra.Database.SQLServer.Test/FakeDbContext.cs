using Microsoft.EntityFrameworkCore;

namespace Infra.Database.SQLServer.Test
{
    public class FakeDbContext
    {
        public static TDbContext Create<TDbContext>() where TDbContext : DbContext
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<TDbContext>();
            dbContextOptionsBuilder.UseInMemoryDatabase("SimpleDashboard");

            var dbContextOptions = dbContextOptionsBuilder.Options;
            var dbContext = Activator.CreateInstance(typeof(TDbContext), dbContextOptions);

            return dbContext as TDbContext;
        }
    }
}
