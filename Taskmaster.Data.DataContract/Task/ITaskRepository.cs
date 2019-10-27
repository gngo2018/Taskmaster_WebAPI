using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taskmaster.Data.DataContract.Task
{
    public interface ITaskRepository
    {
        Task<bool> CreateTask(TaskCreateRAO rao);
        Task<IEnumerable<TaskGetListItemRAO>> GetTasks();
        Task<TaskGetListItemRAO> GetTaskById(int id);
        Task<bool> UpdateTask(TaskUpdateRAO rao);
        Task<bool> DeleteTask(int id);
    }
}
