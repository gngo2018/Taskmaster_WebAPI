using System;
namespace Taskmaster.API.DataContract.Task
{
    public class TaskCreateRequest
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
    }
}
