using CourseMangmentSystemWeb.Data;
using CourseMangmentSystemWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseMangmentSystemWeb.Controllers
{
    public class AdminDepartmentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AdminDepartmentController(ApplicationDbContext db)
        {
            _db = db;
                
        }

        public IActionResult Index()
        {
            IEnumerable<Department> objDepartmentList = _db.Departments.ToList(); 
            return View(objDepartmentList);
        }
        //GET 
        public IActionResult Edit(int?id)
        {
            if (id == 0 || id == null) return NotFound();
            //var departmentObj= _db.Departments.FirstOrDefault(x => x.Id == id);
            var departmentObj = _db.Departments.Find(id); 
            if(departmentObj == null) return NotFound();
            return View(departmentObj);
        }
        //GET 
        public IActionResult Delete(int?id)
        {

            if (id == 0 || id == null) return NotFound();
            //var departmentObj= _db.Departments.FirstOrDefault(x => x.Id == id);
            var departmentObj = _db.Departments.Find(id);
            if (departmentObj == null) return NotFound();
            return View(departmentObj);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete (Department obj)
        {
                _db.Departments.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index"); 
            
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department obj )
        {
            string x=obj.Name;
            if (!((x[0] >= 'a' && x[0] <= 'z') || ((x[0] >= 'A' && x[0] <= 'Z'))))
                ModelState.AddModelError(nameof(obj.Name), "Please Enter letters only !!");
            if (ModelState.IsValid)
            {
                _db.Departments.Add(obj); 
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department obj)
        {
            string x = obj.Name;
            if (!((x[0] >= 'a' && x[0] <= 'z') || ((x[0] >= 'A' && x[0] <= 'Z'))))
                ModelState.AddModelError(nameof(obj.Name), "Please Enter letters only !!");
            if (ModelState.IsValid)
            {
                _db.Departments.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }
    }

}
