using Infra.Database.MySQL.UserStory.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Database.MySQL.UserStory.Configurations
{
    internal class TaskEntityConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.ToTable("Tasks");
            builder.Property(t => t.Id).HasColumnType("NVARCHAR").HasMaxLength(36);
            builder.Property(t => t.Title).HasColumnType("NVARCHAR");
            builder.Property(t => t.Description).HasColumnType("NVARCHAR");
            builder.Property(t => t.OwnerId).HasColumnType("NVARCHAR").HasMaxLength(36);
            builder.Property(t => t.StartedOn).HasColumnType("DATETIME2");
            builder.Property(t => t.Period).HasColumnType("TIME");
            builder.Property(t => t.Status).HasColumnType("NVARCHAR");
            builder.Property(t => t.ModifiedOn).HasColumnType("DATETIME2");
            builder.Property(t => t.ModifiedById).HasColumnType("NVARCHAR").HasMaxLength(36);
            builder.Property(t => t.CreatedOn).HasColumnType("DATETIME2");
            builder.Property(t => t.CreatedById).HasColumnType("NVARCHAR").HasMaxLength(36);
            builder.Property(t => t.UserStoryId).HasColumnType("NVARCHAR").HasMaxLength(36);

            builder.HasKey(t => t.Id);

            #region Relationships

            builder.HasOne(t => t.Owner)
                .WithMany()
                .HasForeignKey(t => t.OwnerId);

            builder.HasOne(t => t.ModifiedBy)
                .WithMany()
                .HasForeignKey(t => t.ModifiedById);

            builder.HasOne(t => t.CreatedBy)
                .WithMany()
                .HasForeignKey(t => t.CreatedById);

            builder.HasOne(t => t.UserStoryInformationEntity)
                .WithMany()
                .HasForeignKey(t => t.UserStoryId);
        }

        #endregion
    }
}
