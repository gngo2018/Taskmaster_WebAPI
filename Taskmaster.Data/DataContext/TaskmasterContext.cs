using System;
using Microsoft.EntityFrameworkCore;
using Taskmaster.Data.Entities;

namespace Taskmaster.Data.DataContext
{
    public class TaskmasterContext : DbContext
    {
        public TaskmasterContext(DbContextOptions<TaskmasterContext> options)
            : base(options)
        {
        }

        public DbSet<TaskDataModel> Task { get; set; }

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
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //    => modelBuilder.ApplyConfiguration(new TaskConfig());
    }
}
