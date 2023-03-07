using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo;
using ToDo.Models;

public class UserRatingController : Controller
{
    private readonly AppDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    private int points;

    public UserRatingController(AppDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var userRatings = await _context.UserRatings.OrderByDescending(ur => ur.TaskCompletedCount).ToListAsync();
        return View(userRatings);
    }

    public async Task<IActionResult> Update(string userId)
    {
        var userRating = await _context.UserRatings.FirstOrDefaultAsync(ur => ur.UserId == userId);
        if (userRating == null)
        {
            userRating = new UserRating
            {
                UserId = userId,
                TaskCompletedCount = 1,
                TotalPoints = points
            };
            _context.UserRatings.Add(userRating);
        }
        else
        {
            userRating.TaskCompletedCount++;
            userRating.TotalPoints += points;
            _context.UserRatings.Update(userRating);
        }
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
