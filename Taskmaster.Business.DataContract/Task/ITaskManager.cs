using System;
using System.Threading.Tasks;

namespace Taskmaster.Business.DataContract.Task
{
    public interface ITaskManager
    {
        Task<bool> CreateTask(TaskCreateDTO dto);
    }
}
