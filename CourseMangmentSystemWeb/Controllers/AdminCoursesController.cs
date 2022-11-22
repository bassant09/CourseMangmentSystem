using CourseMangmentSystemWeb.Data;
using CourseMangmentSystemWeb.Models;
using CourseMangmentSystemWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CourseMangmentSystemWeb.Controllers
{
    public class AdminCoursesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AdminCoursesController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Course> objCoursesList = _db.Courses.Include(e => e.Instractor).Include(e => e.Department); 

            return View(objCoursesList);
        }
        //GET 
        public IActionResult Create()
        {
            ViewBag.DepartmentId = new List<SelectListItem>(
                _db.Departments.Select(
                    e => new SelectListItem { Text = e.Name, Value = e.Id.ToString() }
                    )

                );
            ViewBag.InstractorId = new List<SelectListItem>(
                _db.Instructors.Select(
                    e => new SelectListItem { Text = e.FirstName +" "+ e.SecondName , Value = e.Id.ToString() }
                    )

                );


            return View();
        }
        //POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course obj, IFormFile? PhotoUrl)
        {
            if (ModelState.IsValid)
            {
                if (PhotoUrl != null)
                {

                    var path = ImagesController.UploadImage(_webHostEnvironment, PhotoUrl);
                    obj.PhotoUrl = path;
                }
                
                _db.Courses.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }
        //GET 
        public IActionResult Edit(int?id)
        {

            if (id == null || id == 0) return NotFound();
            ViewBag.DepartmentId = new List<SelectListItem>(
                _db.Departments.Select(
                    e => new SelectListItem { Text = e.Name, Value = e.Id.ToString() }
                    )

                );
            ViewBag.InstractorId = new List<SelectListItem>(
                _db.Instructors.Select(
                    e => new SelectListItem { Text = e.FirstName + " " + e.SecondName, Value = e.Id.ToString() }
                    )

                );
            
            var obj = _db.Courses.Include(e => e.Department).Include(e => e.Instractor).FirstOrDefault(e => e.Id == id);
            if(obj== null) return NotFound();
            return View(obj); 
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( Course obj, IFormFile? PhotoUrl)
        {
            if (obj != null)
            {
                if (PhotoUrl != null)
                {
                    var path=ImagesController.UploadImage(_webHostEnvironment, PhotoUrl);
                    obj.PhotoUrl=path;
                }
                _db.Courses.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);

        }

        //GET 
        public IActionResult Delete(int?id)
        {

            if (id == 0 || id == null) return NotFound();
            var obj = _db.Courses.Include(e => e.Department).Include(e=>e.Instractor) .FirstOrDefault(e => e.Id == id);
            if (obj == null) return NotFound();
            return View(obj);
        }
        //POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Course obj)
        {
            _db.Courses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
