using System;
namespace Taskmaster.Business.DataContract.Task
{
    public class TaskUpdateDTO
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool IsNotStarted { get; set; }
        public bool IsInProgress { get; set; }
        public bool IsCompleted { get; set; }
    }
}
