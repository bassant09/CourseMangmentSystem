using CourseMangmentSystemWeb.Data;
using CourseMangmentSystemWeb.Models;
using CourseMangmentSystemWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CourseMangmentSystemWeb.Controllers
{
    public class AdminInstructorController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AdminInstructorController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            IEnumerable<Instructor> objInstructorList = _db.Instructors.Include(e => e.Department);
            return View(objInstructorList);
        }
        //GET 
        public IActionResult Create()
        {
            ViewBag.DepartmentId = new List<SelectListItem>(
                _db.Departments.Select(
                    e => new SelectListItem { Text = e.Name, Value = e.Id.ToString() }
                    )
                );
            return View();
        }
        //POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Instructor obj, IFormFile? ProfilePicture)
        {
           
            if (ModelState.IsValid)
            {
                if (ProfilePicture != null)
                {
                    var path =ImagesController.UploadImage(_webHostEnvironment, ProfilePicture);
                    obj.ProfilePicture = path; 
                }
                _db.Instructors.Add(obj);
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
            var obj = _db.Instructors.FirstOrDefault(e => e.Id == id);
            if(obj == null) return NotFound();

            return View(obj);
        }
        //POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Instructor obj, IFormFile? ProfilePicture)
        {
            if (ModelState.IsValid)
            {
                if (ProfilePicture != null)
                {
                    var path= ImagesController.UploadImage(_webHostEnvironment, ProfilePicture);
                    obj.ProfilePicture = path; 
                }
                _db.Instructors.Update(obj); 
                _db.SaveChanges();
                return RedirectToAction("Index"); 
            }
      

            return View(obj);
        }
        //GET 
        public IActionResult Delete(int?id)
        {
           
            if (id == 0 || id == null) return NotFound();
            var obj = _db.Instructors.Include(e => e.Department).FirstOrDefault(e => e.Id == id);
            if (obj == null) return NotFound();
            return View(obj);
        }
        //POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Instructor obj)
        {

            
                _db.Instructors.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
 


        
        }
        public IActionResult Details(int?id)
        {
            if (id == null || id == 0) return NotFound();
            var obj = _db.Instructors.Include(e => e.Department).FirstOrDefault(e => e.Id == id);
            if(obj==null) return NotFound();    
            return View(obj);

        }

    }
}
