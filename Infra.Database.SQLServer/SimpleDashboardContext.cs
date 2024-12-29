using Common.Core.DependencyInjection;
using Infra.Database.SQLServer.User.Entities;
using Infra.Database.SQLServer.UserStory.Configurations;
using Infra.Database.SQLServer.UserStory.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.SQLServer
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
