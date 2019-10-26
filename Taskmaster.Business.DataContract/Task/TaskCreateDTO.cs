using System;
namespace Taskmaster.Business.DataContract.Task
{
    public class TaskCreateDTO
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
