using CourseMangmentSystemWeb.Data;
using CourseMangmentSystemWeb.Models;
using CourseMangmentSystemWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseMangmentSystemWeb.Component
{
    public class AuthComponent : ViewComponent 
    {
        private readonly ApplicationDbContext _db; 
        public AuthComponent(ApplicationDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
           if(AuthanticationController.IsLoggedIn(HttpContext))
            {
                if (AuthanticationController.IsInstractor(HttpContext))
                {
                    var obj = (Super)_db.Instructors.Find(AuthanticationController.GetId(HttpContext)); 

                     return View(obj);
                }
                else if (AuthanticationController.IsStudent(HttpContext))
                {
                    var obj = (Super)_db.Students.Find(AuthanticationController.GetId(HttpContext));
                    return View(obj);

                }
            }
           
            return View();
        }
    }
}
