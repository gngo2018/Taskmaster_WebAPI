using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<TaskGetListItemRAO>> GetTasks()
        {
            var query = await _context.Task.ToArrayAsync();
            var rao = _mapper.Map<IEnumerable<TaskGetListItemRAO>>(query);

            return rao;
        }

        public async Task<TaskGetListItemRAO> GetTaskById(int id)
        {
            var query = await _context.Task.FirstOrDefaultAsync(q => q.TaskId == id);
            var rao = _mapper.Map<TaskGetListItemRAO>(query);

            return rao;
        }

        public async Task<bool> UpdateTask(TaskUpdateRAO rao)
        {
            var entity = await _context.Task.SingleOrDefaultAsync(e => e.TaskId == rao.TaskId);

            entity.TaskName = rao.TaskName;
            entity.TaskDescription = rao.TaskDescription;
            entity.DateUpdated = rao.DateUpdated;
            entity.IsNotStarted = rao.IsNotStarted;
            entity.IsInProgress = rao.IsInProgress;
            entity.IsCompleted = rao.IsCompleted;

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteTask(int id)
        {
            var query = await _context.Task.FirstOrDefaultAsync(q => q.TaskId == id);
            _context.Task.Remove(query);

            return await _context.SaveChangesAsync() == 1;

        }
    }
}
