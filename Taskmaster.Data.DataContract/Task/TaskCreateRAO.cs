using System;
namespace Taskmaster.Data.DataContract.Task
{
    public class TaskCreateRAO
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool IsNotStarted { get; set; }
        public bool IsInProgress { get; set; }
        public bool IsCompleted { get; set; }
    }
}
