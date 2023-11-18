using Common.Core.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleDashboard.Common
{
    public static class ServiceContainer
    {
        public static IServiceCollection CreateDefault()
        {
            var container = new ServiceCollection();
            container.RegisterDomain("Application.Services", "Domain.Services", "Infra.Database.MySQL");
            return container;
        }
    }
}
