using System;
using System.Threading.Tasks;

namespace Taskmaster.Data.DataContract.Task
{
    public interface ITaskRepository
    {
        Task<bool> CreateTask(TaskCreateRAO rao);
    }
}
