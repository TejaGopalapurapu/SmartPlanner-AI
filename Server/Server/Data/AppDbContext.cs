// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using Server.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<TaskItem> Tasks { get; set; }
}
