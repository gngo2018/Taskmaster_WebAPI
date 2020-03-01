using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Taskmaster.Data.Entities;

namespace Taskmaster.Data.DataContext
{
    public class TaskmasterContext : IdentityDbContext
        <UserEntity,
        RoleEntity,
        int,
        IdentityUserClaim<int>,
        UserRoleEntity,
        IdentityUserLogin<int>,
        IdentityRoleClaim<int>,
        IdentityUserToken<int>>
    {
        public TaskmasterContext(DbContextOptions<TaskmasterContext> options)
            : base(options)
        {
        }

        public DbSet<UserEntity> UserTableAccess { get; set; }

        public DbSet<TaskDataModel> TaskTableAccess { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskDataModel>(entity =>
            {
                entity.HasKey(prop => prop.TaskId);

                entity.Property(prop => prop.TaskName)
                    .HasMaxLength(25)
                    .IsRequired();

                entity.Property(prop => prop.TaskDescription)
                    .HasMaxLength(150);

                entity.Property(prop => prop.DateCreated)
                    .HasColumnType("TIMESTAMP(0)")
                    .IsRequired();

                entity.Property(prop => prop.DateUpdated)
                    .HasColumnType("TIMESTAMP(0)");

                entity.Property(prop => prop.IsNotStarted)
                    .IsRequired();

                entity.Property(prop => prop.IsInProgress)
                    .IsRequired();

                entity.Property(prop => prop.IsCompleted)
                    .IsRequired();
            });

            modelBuilder.Entity<UserRoleEntity>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
    }
}
