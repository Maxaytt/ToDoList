using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDo.Models;

namespace ToDo
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<TodoTask> TodoTasks { get; set; }
        public DbSet<UserStatistic> UserStatistics { get; set; }
        public DbSet<TaskCategory> TaskCategories { get; set; }
    }

}
