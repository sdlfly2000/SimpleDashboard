using Common.Core.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleDashboard.Extentions
{
    public static class ServiceContainer
    {
        public static IServiceCollection CreateDefaultForUnitTest()
        {
            var container = new ServiceCollection();

            container.AddMemoryCache();
            container.AddSQLServerDatabase("server=homeserver;database=SimpleDashboard;uid=sdlfly2000;password=sdl@1215;");
            container.RegisterDomain("Application.Services", "Domain.Services", "Infra.Database.SQLServer");
            return container;
        }
    }
}
