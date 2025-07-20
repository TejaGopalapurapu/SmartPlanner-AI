using Microsoft.AspNetCore.Mvc;
using Server.Models;
using SmartPlanner.Services;
using System.Threading.Tasks;

namespace SmartPlanner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TasksController()
        {
            _taskService = new TaskService();
        }

        [HttpGet]
        public IActionResult Get() => Ok(_taskService.GetTodayTasks());

        [HttpPost]
        public IActionResult Post([FromBody] TaskItem task)
        {
            _taskService.Add(task);
            var updatedTasks = _taskService.GetTodayTasks();
            return Ok(updatedTasks);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TaskItem updatedTask)
        {
            var success = _taskService.Update(id, updatedTask);
            if (!success) return NotFound();

            return Ok(_taskService.GetTodayTasks());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _taskService.Delete(id);
            var updatedTasks = _taskService.GetTodayTasks();
            return Ok(updatedTasks);
        }
    }
}
