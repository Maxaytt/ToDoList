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

            var statistic = await _context.userStatistics
                 .Where(s => s.userId == userId)
                 .ToListAsync();
                
            return View(statistic);
        }
        
    }
}
