using Microsoft.EntityFrameworkCore;
using ToDo.Models;

namespace ToDo
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<TodoTask> TodoTasks { get; set; } = default;
    }
}
