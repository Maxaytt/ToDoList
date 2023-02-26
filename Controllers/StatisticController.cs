using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ToDo;

namespace TodoList.Controllers
{
    public class StatisticController : Controller
    {
        private AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public StatisticController(AppDbContext context, UserManager<IdentityUser> userManager) 
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: TodoTasks
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var statistic = await _context.userStatistics.FirstOrDefaultAsync(s => s.UserId == userId);

            //This should be in method
            var group = _context.TodoTasks.Where(t => t.CompletedAt < t.Deadline && t.UserId == userId && t.IsCompleted == true);
            var count = await group.CountAsync();

            var fullTime = (float)group.Average(t => EF.Functions.DateDiffMinute(t.CreatedAt, t.Deadline));
            var executionTime = (float)group.Average(t => EF.Functions.DateDiffMinute(t.CreatedAt, t.CompletedAt));

            var averageExecutionTime = (executionTime / fullTime) * 100;
            statistic.AvgExecutionTime = 100.0f - averageExecutionTime;





            //var difference = (float)group.Average(t => EF.Functions.DateDiffDay(t.CompletedAt, t.Deadline));
            //var averageExecutionTime = count == 0 ? 0 : (float)group.Average(t => EF.Functions.DateDiffDay(t.CompletedAt, t.Deadline)) / count;
            //


            return View(statistic);
        }
        
    }
}
