using Microsoft.AspNetCore.Mvc;

namespace TodoList.Controllers
{
    public class CategoryController : Controller
    {
        //Get
        public IActionResult Index()
        {
            return View();
        }
        //Get
        public IActionResult Create() 
        {
            return View();
        }
    }
}
