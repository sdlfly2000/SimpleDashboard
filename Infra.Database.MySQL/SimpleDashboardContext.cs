using Common.Core.DependencyInjection;
using Infra.Database.MySQL.User.Entities;
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
        public DbSet<UserEntity> UserEntities { get; set; }
    }
}
