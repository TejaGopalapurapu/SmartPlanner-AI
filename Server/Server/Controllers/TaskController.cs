using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private static List<TaskItem> tasks = new();
        private static int nextId = 1;

        [HttpPost]
        public IActionResult AddTask([FromBody] TaskItem task)
        {
            task.Id = nextId++;
            tasks.Add(task);
            return Ok(tasks);
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            return Ok(tasks);
        }
    }
}
