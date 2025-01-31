using Infra.Database.SQLServer.UserStory.Entities;
using Microsoft.EntityFrameworkCore;
using Task = Infra.Database.SQLServer.UserStory.Entities.Task;

namespace Infra.Database.SQLServer.UserStory.Context;

public partial class UserStoryDbContext : DbContext
{
    public UserStoryDbContext()
    {
    }

    public UserStoryDbContext(DbContextOptions<UserStoryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<UserStoryInformation> UserStoryInformations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tasks__3214EC07F3FDF481");

            entity.Property(e => e.CreatedById).HasMaxLength(36);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ModifiedById).HasMaxLength(36);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.OwnerId).HasMaxLength(36);
            entity.Property(e => e.StartedOn).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.UserStory).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.UserStoryId)
                .HasConstraintName("FK__Tasks__UserStory__693CA210");
        });

        modelBuilder.Entity<UserStoryInformation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserStor__3214EC07E439F9A1");

            entity.ToTable("UserStoryInformation");

            entity.Property(e => e.CreatedById).HasMaxLength(36);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedById).HasMaxLength(36);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.OwnerId).HasMaxLength(36);
            entity.Property(e => e.StartedOn).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
