using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskmaster.Data.Entities;

namespace Taskmaster.Data.DataConfig
{
    public class TaskConfig : IEntityTypeConfiguration<TaskDataModel>
    {
        public void Configure(EntityTypeBuilder<TaskDataModel> builder)
        {
            builder.HasKey(prop => prop.TaskId);

            builder.Property(prop => prop.TaskName)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(prop => prop.TaskDescription)
                .HasMaxLength(150);

            builder.Property(prop => prop.DateCreated)
                .HasColumnType("TIMESTAMP(0)")
                .IsRequired();

            builder.Property(prop => prop.DateUpdated)
                .HasColumnType("TIMESTAMP(0)");

            builder.Property(prop => prop.IsNotStarted)
                .IsRequired();

            builder.Property(prop => prop.IsInProgress)
                .IsRequired();

            builder.Property(prop => prop.IsCompleted)
                .IsRequired();
        }

    }
}
