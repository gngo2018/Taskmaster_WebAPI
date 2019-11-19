using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Taskmaster.API.DataContract.Task;
using Taskmaster.Business.DataContract.Task;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taskmaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITaskManager _manager;

        public TaskController(IMapper mapper, ITaskManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = _mapper.Map<TaskCreateDTO>(request);
            dto.DateCreated = DateTime.Now;
            dto.IsNotStarted = true;
            dto.IsInProgress = false;
            dto.IsCompleted = false;

            if (await _manager.CreateTask(dto))
                return StatusCode(201);

            throw new Exception();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = await _manager.GetTasks();
            var response = _mapper.Map<IEnumerable<TaskGetListItemResponse>>(dto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = await _manager.GetTaskById(id);
            var response = _mapper.Map<TaskGetListItemResponse>(dto);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask(TaskUpdateRequest request)        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = _mapper.Map<TaskUpdateDTO>(request);
            dto.DateUpdated = DateTime.Now;

            if (await _manager.UpdateTask(dto))
                return StatusCode(202);

            throw new Exception();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            if (await _manager.DeleteTask(id))
                return StatusCode(207);

            throw new Exception();
        }
    }
}
