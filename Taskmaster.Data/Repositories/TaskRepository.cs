using System;
using System.Threading.Tasks;
using AutoMapper;
using Taskmaster.Data.DataContext;
using Taskmaster.Data.DataContract.Task;
using Taskmaster.Data.Entities;

namespace Taskmaster.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IMapper _mapper;
        private readonly TaskmasterContext _context;

        public TaskRepository(IMapper mapper, TaskmasterContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> CreateTask(TaskCreateRAO rao)
        {
            var entity = _mapper.Map<TaskDataModel>(rao);

            await _context.Task.AddAsync(entity);

            return await _context.SaveChangesAsync() == 1;
        }
    }
}
