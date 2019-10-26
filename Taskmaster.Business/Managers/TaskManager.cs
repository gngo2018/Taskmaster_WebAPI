using System;
using System.Threading.Tasks;
using AutoMapper;
using Taskmaster.Business.DataContract.Task;
using Taskmaster.Data.DataContract.Task;

namespace Taskmaster.Business.Managers
{
    public class TaskManager : ITaskManager
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _repository;

        public TaskManager(IMapper mapper, ITaskRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<bool> CreateTask(TaskCreateDTO dto)
        {
            var rao = _mapper.Map<TaskCreateRAO>(dto);

            if (await _repository.CreateTask(rao))
                return true;

            throw new NotImplementedException();
        }
    }
}
