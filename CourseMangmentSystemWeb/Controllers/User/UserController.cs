using CourseMangmentSystemWeb.Controllers.InstructorControllers;
using CourseMangmentSystemWeb.Data;
using CourseMangmentSystemWeb.Models;
using CourseMangmentSystemWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.Remoting;

namespace CourseMangmentSystemWeb.Controllers.User
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Login()
        {
             return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Login(string email, string password)
        {
            if(email!=null&& password!=null)
            {
               var student= _db.Students.FirstOrDefault(e => e.Password == password && e.Email == email);
                if (student != null)
                {
                    AuthanticationController.SetStudent(HttpContext,student.Id.ToString()); 

                    return RedirectToAction("Index", "Student"); 

                }
                var instractor= _db.Instructors.FirstOrDefault(e => e.Password == password && e.Email == email);
                if(instractor != null)
                {
                    AuthanticationController.SetInstractor(HttpContext,instractor.Id.ToString());
                   
                    return RedirectToAction("Index", "Instructor");

                }
                var admin = _db.Admins.FirstOrDefault(e => e.Password == password && e.Email == email);
                if (admin != null)
                {
                    AuthanticationController.SetAdmin(HttpContext, admin.Id.ToString());
                    return RedirectToAction("Index", "Admin");

                }
               




            }
            ViewBag.error = "User n't Found";


            return View();
        }
        public IActionResult Register(Student obj )
        {
            if(ModelState.IsValid)
            {
                //var z = obj.Email;
                //var pass = obj.Password;
                //var first=obj.FirstName;
                //var second = obj.SecondName;
                //var name = first + second;
                //if (z.Contains("admin"))
                //{
                //   Admin admin = new Admin();
                //    admin.Email = z;
                //    admin.Password = pass;
                //    admin.Name = name; 
                //    _db.Admins.Add(admin);
                //    _db.SaveChanges();

                //}
                _db.Students.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Login");       

            } 
            return View(obj);
        }
        public IActionResult Logout()
        {
            AuthanticationController.LogOut(HttpContext);
            return RedirectToAction("Index","Home");
        }
        }
}
