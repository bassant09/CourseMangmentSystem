using CourseMangmentSystemWeb.Data;
using CourseMangmentSystemWeb.Models;
using CourseMangmentSystemWeb.Services;
using CourseMangmentSystemWeb.ViewHanka;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace CourseMangmentSystemWeb.Controllers.InstructorControllers
{
    public class InstructorController : Controller
    {
        private readonly ApplicationDbContext _db;
        public static int InstructorId = 9; 
        public InstructorController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowMyCourses()
        {
            var obj = _db.Courses.Include(e=>e.Department).Where(e => e.InstractorId == AuthanticationController.GetId(HttpContext));  
            return View(obj);
        }
        public IActionResult Request()
        {
            var obj = _db.RequestCourses
                .Include(e=>e.Student)
                .Include(e => e.Course)
                .Include(e => e.Course.Department)
                .Where(e => e.Course.InstractorId == AuthanticationController.GetId(HttpContext));
            return View(obj);
        }
        public IActionResult Accept(int CourseId , int StudentId)
        {
            if (CourseId == null || StudentId == null) return NotFound(); 
             var obj=_db.RequestCourses.FirstOrDefault(e=>e.CourseId==CourseId && e.StudentId== AuthanticationController.GetId(HttpContext)); 
            if(obj==null) return NotFound();
            _db.RequestCourses.Remove(obj);
            var objec = new StudentCourse(); 
            objec.CourseId = CourseId;
            objec.StudentId = StudentId; 
            _db.StudentCourses.Add(objec);
            _db.SaveChanges(); 
            return RedirectToAction("Request");
        }
        public IActionResult Deny(int CourseId, int StudentId)
        {
            if (CourseId == null || StudentId == null) return NotFound();
            var obj = _db.RequestCourses.FirstOrDefault(e => e.CourseId == CourseId && e.StudentId == AuthanticationController.GetId(HttpContext));
            if (obj == null) return NotFound();
            _db.RequestCourses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Request");
        }
        [HttpGet]
        public IActionResult AssignTask(int CourseId)
        {
            if (CourseId == null) return NotFound();
            //var x =_db.Courses.FirstOrDefault(e => e.Id == id);
            CourseTask obj= new CourseTask();
            obj.CourseId= CourseId;
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AssignTask(CourseTask obj)
        {
           
                
                _db.Tasks.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("ShowMyCourses"); 
            
           
         
        }
        public IActionResult Logout()
        {
            AuthanticationController.LogOut(HttpContext);
            return RedirectToAction("Index", "Home");
        }

        //public  static Class ShowProfile(ApplicationDbContext _db,HttpContext httpContext)
        //{
        //    var obj = _db.Instructors.Find(AuthanticationController.GetId(httpContext)); 
        //    Class x = new Class();
        //    x.Name = obj.FirstName + obj.SecondName;
        //    x.PhotoUrl = obj.ProfilePicture;
        //    return x;
        //}

    }
}
