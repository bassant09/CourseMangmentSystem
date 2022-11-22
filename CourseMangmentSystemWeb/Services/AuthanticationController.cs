using CourseMangmentSystemWeb.Models;
using CourseMangmentSystemWeb.ViewHanka;
using Microsoft.AspNetCore.Mvc;

namespace CourseMangmentSystemWeb.Services
{
    public class AuthanticationController : Controller
    {
        public const string USER_ID = "USER_ID";
        public const string ROLE_NAME = "ROLE";
        public const string STUDENT = "STUDENT";
        public const string INSTRACTOR = "INSTRACTOR";
        public const string ADMIN = "ADMIN";
        public static void SetStudent(HttpContext httpContext, string id)
        {
            httpContext.Session.SetString(USER_ID, id);
            httpContext.Session.SetString(ROLE_NAME, STUDENT);
        }
        public static void SetInstractor(HttpContext httpContext, string id)
        {
            httpContext.Session.SetString(USER_ID, id);
            httpContext.Session.SetString(ROLE_NAME, INSTRACTOR);
        }
        public static void SetAdmin(HttpContext httpContext, string id)
        {
            httpContext.Session.SetString(USER_ID, id);
            httpContext.Session.SetString(ROLE_NAME, ADMIN);
        }
        public static bool IsStudent(HttpContext httpContext)
        {
            if (httpContext.Session.GetString(ROLE_NAME) != null)
            {
                return httpContext.Session.GetString(ROLE_NAME) == STUDENT;
            }

            return false;
        }
        public static bool IsInstractor(HttpContext httpContext)
        {
            if (httpContext.Session.GetString(ROLE_NAME) != null)
            {
                return httpContext.Session.GetString(ROLE_NAME) == INSTRACTOR;
            }

            return false;
        }

        public static bool IsAdmin(HttpContext httpContext)
        {
            if (httpContext.Session.GetString(ROLE_NAME) != null)
            {
                return httpContext.Session.GetString(ROLE_NAME) == ADMIN;
            }

            return false;
        }
        public static int GetId(HttpContext httpContext )
        {
            if(httpContext.Session.GetString(USER_ID) != null)
            {
                return int.Parse(httpContext.Session.GetString(USER_ID)); 
            }
            return -1;

        }
        public static bool IsLoggedIn(HttpContext httpContext)
        {
            if (httpContext.Session.GetString(USER_ID) != null) return true;
            return false;
        }
        public static void LogOut(HttpContext httpContext)
        {
            httpContext.Session.Remove(USER_ID);
            httpContext.Session.Remove(ROLE_NAME);
        }
        

    }
}
