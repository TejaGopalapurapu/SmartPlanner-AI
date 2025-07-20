namespace Server.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime Date { get; set; }  // for filtering today's tasks
    }

}
