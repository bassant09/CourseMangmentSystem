using Microsoft.AspNetCore.Mvc;

namespace CourseMangmentSystemWeb.Controllers
{
    public class AdminCoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {

            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
