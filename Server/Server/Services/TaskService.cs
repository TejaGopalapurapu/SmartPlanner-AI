using Server.Models;

namespace SmartPlanner.Services
{
    public class TaskService
    {
        private static List<TaskItem> tasks = new();

        public List<TaskItem> GetTodayTasks()
        {
            return tasks.Where(t => t.Date.Date == DateTime.Today).ToList();
        }

        public void Add(TaskItem task)
        {
            task.Id = tasks.Count + 1;
            task.Date = DateTime.Today;
            tasks.Add(task);
        }

        public bool Update(int id, TaskItem updatedTask)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return false;

            task.Text = updatedTask.Text;
            task.IsCompleted = updatedTask.IsCompleted;
            task.Date = updatedTask.Date;

            return true;
        }

        public void Delete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null) tasks.Remove(task);
        }
    }
}
