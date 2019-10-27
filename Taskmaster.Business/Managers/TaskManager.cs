using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<TaskGetListItemDTO>> GetTasks()
        {
            var rao = await _repository.GetTasks();
            var dto = _mapper.Map<IEnumerable<TaskGetListItemDTO>>(rao);

            return dto;
        }

        public async Task<TaskGetListItemDTO> GetTaskById(int id)
        {
            var rao = await _repository.GetTaskById(id);
            var dto = _mapper.Map<TaskGetListItemDTO>(rao);

            return dto;
        }

        public async Task<bool> UpdateTask(TaskUpdateDTO dto)
        {
            var rao = _mapper.Map<TaskUpdateRAO>(dto);

            if (await _repository.UpdateTask(rao))
                return true;

            throw new NotImplementedException();
        }

        public async Task<bool> DeleteTask(int id)
        {
            if (await _repository.DeleteTask(id))
                return true;

            throw new NotImplementedException();
        }
    }
}
