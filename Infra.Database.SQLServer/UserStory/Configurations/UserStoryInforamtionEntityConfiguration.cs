using Infra.Database.SQLServer.UserStory.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Database.SQLServer.UserStory.Configurations
{
    internal class UserStoryInforamtionEntityConfiguration : IEntityTypeConfiguration<UserStoryInformationEntity>
    {
        public void Configure(EntityTypeBuilder<UserStoryInformationEntity> builder)
        {
            builder.ToTable("UserStoryInformation");

            builder.Property(information => information.Id).HasColumnType("NVARCHAR").HasMaxLength(50);
            builder.Property(information => information.Title).HasColumnType("NVARCHAR");
            builder.Property(information => information.Description).HasColumnType("NVARCHAR");
            builder.Property(information => information.StartedOn).HasColumnType("DATETIME");
            builder.Property(information => information.Period).HasColumnType("TIME");
            builder.Property(information => information.Status).HasColumnType("NVARCHAR").HasMaxLength(20);
            builder.Property(information => information.ModifiedOn).HasColumnType("DATETIME");
            builder.Property(information => information.ModifiedById).HasColumnType("NVARCHAR").HasMaxLength(50);
            builder.Property(information => information.CreatedOn).HasColumnType("DATETIME2");
            builder.Property(information => information.CreatedById).HasColumnType("NVARCHAR").HasMaxLength(50);
            builder.Property(information => information.OwnerId).HasColumnType("NVARCHAR").HasMaxLength(50);

            builder.HasKey(information => information.Id);

            //builder.HasOne(information => information.Owner)
            //    .WithMany()
            //    .HasForeignKey(information => information.OwnerId);
            //builder.HasOne(information => information.ModifiedBy)
            //    .WithMany()
            //    .HasForeignKey(information => information.ModifiedById);
            //builder.HasOne(information => information.CreatedBy)
            //    .WithMany()
            //    .HasForeignKey(information => information.CreatedById);

            builder.HasIndex(information => information.OwnerId);
            builder.HasIndex(information => information.ModifiedById);
            builder.HasIndex(information => information.CreatedById);
        }
    }
}
