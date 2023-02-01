using Microsoft.EntityFrameworkCore;
using ToDo.Models;
using ToDo.Services.Interfaces;

namespace ToDo.Services
{
    /*public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;
        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TodoTask> GetAll()
        {
            return _context.TodoTasks.ToList();
        }

        public async Task<TodoTask> GetById(int id)
        {
            return await _context.TodoTasks.FirstOrDefaultAsync(x => x.Id == id) ?? new TodoTask();
        }

        public void Create(TodoTask task)
        {
            _context.TodoTasks.Add(task);
            _context.SaveChanges();
        }

        public async Task Update(int id, TodoTask task)
        {
            var existingTask = await _context.TodoTasks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingTask == null)
            {
                throw new Exception("Task not found");
            }
            existingTask.Description = task.Description;
            existingTask.IsCompleted = task.IsCompleted;
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var task = await _context.TodoTasks.FirstOrDefaultAsync(x => x.Id == id);
            if (task != null)
            {
                _context.TodoTasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
    */
}
