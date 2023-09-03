using Infra.Database.MySQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Common
{
    public static class SimpleDashboardServiceExtention
    {
        public static IServiceCollection AddMySQLDatabase(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<SimpleDashboardContext>(
                options => options.UseMySql(
                    ServerVersion.AutoDetect(connectionString),
                    b => b.MigrationsAssembly("Infra.Database.MySQL")));
        }
    }
}
