using CourseMangmentSystemWeb.Data;
using CourseMangmentSystemWeb.Models;
using CourseMangmentSystemWeb.Services;
using CourseMangmentSystemWeb.ViewHanka;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CourseMangmentSystemWeb.Controllers.StudentControllers
{
    public class RequestCoursesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public static int StudentId = 2;

        public RequestCoursesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

           //var  objList = _db.StudentCourses.Include(e => e.Course).Where(e => e.StudentId == StudentId).Select(e => e.Course);
           // var courses = _db.Courses.Except(objList).Include(e => e.Instractor).Include(e => e.Department);
           
            var objList = _db.StudentCourses.Include(e => e.Course).Where(e => e.StudentId == AuthanticationController.GetId(HttpContext)).Select(e => e.Course);
            var courses = _db.Courses.Except(objList).Include(e => e.Instractor).Include(e => e.Department)
                .Select(e =>
                    new ViewCourses
                    {
                        Course = e,
                        IsRequested = _db.RequestCourses
                                        .Any(j => j.StudentId == AuthanticationController.GetId(HttpContext) && j.CourseId == e.Id)
                    }
                ) ;
            return View(courses);
        }
      
        public IActionResult Request(int id )
        {
            if (id == null || id == 0) return NotFound();
            var obj = new RequestCourse();
            obj.CourseId = id;
            obj.StudentId = AuthanticationController.GetId(HttpContext); 
            _db.RequestCourses.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index"); 
        }
    }
}
