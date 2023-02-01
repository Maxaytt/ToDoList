using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Models;
using ToDo.Services.Interfaces;

namespace ToDo.Controllers
{
    public class TodoController : Controller
    {
        private readonly AppDbContext _context;

        public TodoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TodoTasks
        public async Task<IActionResult> Index()
        {
            var todoTasks = await _context.TodoTasks
                .Where(t => t.IsCompleted == false)
                .OrderBy(t => t.Priority)
                .ToListAsync(); 
            return View(todoTasks);
        }

        //GET: TodoTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TodoTasks == null)
            {
                return NotFound();
            }

            var task = await _context.TodoTasks.FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        //GET: TodoTasks/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TodoTask task)
        {
            if (ModelState.IsValid)
            {
                task.CreatedAt = DateTime.Now;
                _context.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        //GET: TodoTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TodoTasks == null)
            {
                return NotFound();
            }
            var task = await _context.TodoTasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TodoTask task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(task);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoTaskExists(task.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        //GET: TodoTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TodoTasks == null)
            {
                return NotFound();
            }

            var task = await _context.TodoTasks.FirstOrDefaultAsync(m => m.Id == id);
            if(task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _context.TodoTasks.FindAsync(id);
            if(task != null)
            {
                _context.TodoTasks.Remove(task);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Update(int taskId, bool isCompleted)
        {
            var task = await _context.TodoTasks.FindAsync(taskId);
            if (task == null)
            {
                return NotFound();
            }
            task.IsCompleted = isCompleted;
			task.CompletedAt = DateTime.Now;
			_context.Update(task);
            await _context.SaveChangesAsync();
            return Ok();
        }

        public async Task<IActionResult> Completed()
        {
            var task = await _context.TodoTasks
                .Where(t => t.IsCompleted == true)
				.OrderBy(t => t.CompletedAt)
				.ToListAsync();
			return View(task);
        }
		
		private bool TodoTaskExists(int id)
        {
            return _context.TodoTasks.Any(e => e.Id == id);
        }
    }
}
