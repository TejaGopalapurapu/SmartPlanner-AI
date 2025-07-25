using Microsoft.AspNetCore.Mvc;
using Server.Models;
using SmartPlanner.Services;

namespace SmartPlanner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TasksController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_taskService.GetTodayTasks());

        [HttpPost]
        public IActionResult Post([FromBody] TaskItem task)
        {
            _taskService.Add(task);
            return Ok(_taskService.GetTodayTasks());
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TaskItem updatedTask)
        {
            updatedTask.Id = id;
            bool success = _taskService.Update(updatedTask); // Explicitly declare the variable as bool
            if (!success) return NotFound();
            return Ok(_taskService.GetTodayTasks());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _taskService.Delete(id);
            return Ok(_taskService.GetTodayTasks());
        }
    }
}
