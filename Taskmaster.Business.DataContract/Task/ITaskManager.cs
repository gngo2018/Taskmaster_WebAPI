using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taskmaster.Business.DataContract.Task
{
    public interface ITaskManager
    {
        Task<bool> CreateTask(TaskCreateDTO dto);
        Task<IEnumerable<TaskGetListItemDTO>> GetTasks();
        Task<TaskGetListItemDTO>GetTaskById(int id);
        Task<bool> UpdateTask(TaskUpdateDTO dto);
        Task<bool> DeleteTask(int id);
    }
}
