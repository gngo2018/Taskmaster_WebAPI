using System;
namespace Taskmaster.API.DataContract.Task
{
    public class TaskUpdateRequest
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
