using CourseMangmentSystemWeb.Data;
using CourseMangmentSystemWeb.Models;
using CourseMangmentSystemWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CourseMangmentSystemWeb.Controllers
{
    public class AdminStudentsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AdminStudentsController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Student> objStudentList = _db.Students.ToList();

            return View(objStudentList);
        }
        public IActionResult Create()
        {

            return View();
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj, IFormFile? ProfilePicture)
        {
            if (ModelState.IsValid)
            {
                if (ProfilePicture != null)
                {
                    var path = ImagesController.UploadImage(_webHostEnvironment, ProfilePicture);
                    obj.ProfilePicture = path;
                }
                _db.Students.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        //GET
        public IActionResult Edit(int?id)
        {
            if (id == 0 || id == null) return NotFound();
            var obj = _db.Students.Find(id); 
            if (obj == null) return NotFound();

            return View(obj);
        }
        //POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student obj , IFormFile? ProfilePicture)
        {
            if (ModelState.IsValid)
            {
                if(ProfilePicture != null)
                {
                    var path=ImagesController.UploadImage(_webHostEnvironment, ProfilePicture);
                    obj.ProfilePicture = path; 
                }
                _db.Students.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index"); 
            }
        

            return View(obj);
        }
        //GET 
        public IActionResult Delete(int?id)
        {
            if (id == 0 || id == null) return NotFound();
            var obj = _db.Students.Find(id);
            if (obj == null) return NotFound();
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Student obj)
        {
             _db.Students.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
    
        }
        public IActionResult Details (int? id)
        {
            if (id == 0 || id == null) return NotFound();
            var obj = _db.Students.Find(id);
            if (obj == null) return NotFound();
            return View(obj);
        }
       
        public IActionResult ShowCourses(int?id)
        {
            var obj = _db.StudentCourses.Include(e => e.Student).Include(e => e.Course).Include(e => e.Course.Instractor).Include(e => e.Course.Department). Where(e => e.StudentId == id).Select(e => e.Course);
            
       

            return View(obj);
        }
        //public IActionResult CreateStudentCourse(int?id)
        //{
        //    if (id == null||id==0)
        //    {
        //        return NotFound(); 
        //    }
        //    var obj= _db.StudentCourses.Include(e => e.Student).Include(e => e.Course).Include(e => e.Course.Instractor).Include(e => e.Course.Department).Where(e => e.CourseId == id).Select(e => e.Course);
        //    return View(obj);
        //}
        public IActionResult CreateStudentCourse()
        {
            ViewBag.StudentId = new List<SelectListItem>(
                _db.Students.Select(
                    e => new SelectListItem { Text = e.FirstName + " " + e.SecondName, Value = e.Id.ToString() }
                    )

                );
            ViewBag.CourseId = new List<SelectListItem>(
                _db.Courses.Select(
                    e => new SelectListItem { Text = e.Name, Value = e.Id.ToString() }
                    )

                );


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateStudentCourse(StudentCourse obj )
        {
            if (obj != null)
            {
                _db.StudentCourses.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("ShowCourses", new {id=obj.StudentId});  
            }


            return View(obj);
        }
    }
}
