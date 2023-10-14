using Common.Core.DependencyInjection;
using Infra.Database.MySQL.User.Entities;
using Infra.Database.MySQL.UserStory.Configurations;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserStoryInforamtionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TaskEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserStoryInformationEntity> UserStoryInformationEntities { get; set; }
        public DbSet<UserEntity> UserEntities { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
    }
}
