using Microsoft.AspNetCore.Mvc;

namespace CourseMangmentSystemWeb.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
