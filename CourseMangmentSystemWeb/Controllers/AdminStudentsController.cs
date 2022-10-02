using CourseMangmentSystemWeb.Data;
using CourseMangmentSystemWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseMangmentSystemWeb.Controllers
{
    public class AdminStudentsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AdminStudentsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Student> objStudentList = _db.Students.ToList();

            return View(objStudentList);
        }
       // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

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
