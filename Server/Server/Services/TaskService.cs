using Server.Models;

namespace SmartPlanner.Services 
{
    public class TaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public List<TaskItem> GetTodayTasks() =>
            _context.Tasks.Where(t => t.Date.Date == DateTime.Today).ToList();

        public void Add(TaskItem task)
        {
            task.Date = DateTime.Now;
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        public bool Update(TaskItem updated)
        {
            var existing = _context.Tasks.Find(updated.Id);
            if (existing != null)
            {
                existing.Text = updated.Text;
                existing.IsCompleted = updated.IsCompleted;
                _context.SaveChanges();
                return true;
            }
            return false;
        }


    }
}
