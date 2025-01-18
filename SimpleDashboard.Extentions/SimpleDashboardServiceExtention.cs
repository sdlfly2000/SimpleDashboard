using Infra.Database.SQLServer;
using Infra.Database.SQLServer.User.Entities;
using Infra.Database.SQLServer.UserStory.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleDashboard.Extentions
{
    public static class SimpleDashboardServiceExtention
    {
        //public static IServiceCollection AddMySQLDatabase(this IServiceCollection services, string connectionString)
        //{
        //    return services.AddDbContext<SimpleDashboardContext>(
        //        options => options.UseMySql(
        //            connectionString,
        //            ServerVersion.AutoDetect(connectionString),
        //            b => b.MigrationsAssembly("Infra.Database.MySQL")));
        //}

        public static IServiceCollection AddSQLServerDatabase(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<UserDbContext>(
                    options => options.UseSqlServer(
                    connectionString,
                    b => b.MigrationsAssembly("Infra.Database.SQLServer")))
                .AddDbContext<UserStoryDbContext>(
                    options => options.UseSqlServer(
                    connectionString,
                    b => b.MigrationsAssembly("Infra.Database.SQLServer")));
        }
    }
}
