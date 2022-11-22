using CourseMangmentSystemWeb.Data;
using CourseMangmentSystemWeb.Models;
using CourseMangmentSystemWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;

namespace CourseMangmentSystemWeb.Controllers.StudentControllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public static int StudentId = 2;
        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowCourses()
        {
            IEnumerable<StudentCourse> objList = _db.StudentCourses.Where(e => e.StudentId == AuthanticationController.GetId(HttpContext)).Include(e => e.Course);    
            return View(objList);
        }
        //GET
        public IActionResult CourseDetails(int? id)
        {
            if(id==0||id==null) return NotFound();
            var zeft = _db.Courses.Include(e => e.Department).Include(e => e.Instractor).FirstOrDefault(e => e.Id == id);
            if (zeft==null) return NotFound();
            return View(zeft);
        }
        public IActionResult ShowTask(int? CourseId)
        {
            if (CourseId == 0 || CourseId == null) return NotFound();
            var obj = _db.Tasks.Include(e=>e.Course).Where(e => e.CourseId == CourseId); 
            return View(obj);
        }
    }
}
