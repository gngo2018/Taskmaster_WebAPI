using System;
using Microsoft.EntityFrameworkCore;
using Taskmaster.Data.DataConfig;
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
            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //    => modelBuilder.ApplyConfiguration(new TaskConfig());
    }
}
