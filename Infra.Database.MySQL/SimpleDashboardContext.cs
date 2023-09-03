using Common.Core.DependencyInjection;
using Infra.Database.MySQL.UserStory.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.MySQL
{
    [ServiceLocate(typeof(ISimpleDashboardContext), ServiceType.Scoped)]
    public class SimpleDashboardContext : DbContext, ISimpleDashboardContext
    {
        public SimpleDashboardContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserStoryInformationEntity> userStoryInformationEntities { get; set; }
    }
}
