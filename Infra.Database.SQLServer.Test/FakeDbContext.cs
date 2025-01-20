using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Database.SQLServer.Test
{
    public class FakeDbContext
    {
        public static (TDbContext,ServiceProvider) Create<TDbContext>() where TDbContext : DbContext
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<TDbContext>(opt => opt.UseInMemoryDatabase("SimpleDashboard"));
            var services = serviceCollection.BuildServiceProvider();
            return (services.GetRequiredService<TDbContext>(),services);
        }
    }
}
