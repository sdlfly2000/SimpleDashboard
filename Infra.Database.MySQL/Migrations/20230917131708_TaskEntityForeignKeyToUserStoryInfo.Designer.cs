﻿// <auto-generated />
using System;
using Infra.Database.MySQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.Database.MySQL.Migrations
{
    [DbContext(typeof(SimpleDashboardContext))]
    [Migration("20230917131708_TaskEntityForeignKeyToUserStoryInfo")]
    partial class TaskEntityForeignKeyToUserStoryInfo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Infra.Database.MySQL.User.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("UserEntities");
                });

            modelBuilder.Entity("Infra.Database.MySQL.UserStory.Entities.TaskEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("ModifiedById")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("char(36)");

                    b.Property<TimeSpan>("Period")
                        .HasColumnType("time(6)");

                    b.Property<DateTime>("StartedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserStoryId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("OwnerId");

                    b.HasIndex("UserStoryId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Infra.Database.MySQL.UserStory.Entities.UserStoryInformationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("ModifiedById")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("char(36)");

                    b.Property<TimeSpan>("Period")
                        .HasColumnType("time(6)");

                    b.Property<DateTime>("StartedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("OwnerId");

                    b.ToTable("userStoryInformationEntities");
                });

            modelBuilder.Entity("Infra.Database.MySQL.UserStory.Entities.TaskEntity", b =>
                {
                    b.HasOne("Infra.Database.MySQL.User.Entities.UserEntity", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infra.Database.MySQL.User.Entities.UserEntity", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infra.Database.MySQL.User.Entities.UserEntity", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infra.Database.MySQL.UserStory.Entities.UserStoryInformationEntity", "UserStoryInformationEntity")
                        .WithMany()
                        .HasForeignKey("UserStoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("ModifiedBy");

                    b.Navigation("Owner");

                    b.Navigation("UserStoryInformationEntity");
                });

            modelBuilder.Entity("Infra.Database.MySQL.UserStory.Entities.UserStoryInformationEntity", b =>
                {
                    b.HasOne("Infra.Database.MySQL.User.Entities.UserEntity", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infra.Database.MySQL.User.Entities.UserEntity", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infra.Database.MySQL.User.Entities.UserEntity", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("ModifiedBy");

                    b.Navigation("Owner");
                });
#pragma warning restore 612, 618
        }
    }
}
