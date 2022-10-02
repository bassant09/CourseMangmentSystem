using System.ComponentModel.DataAnnotations;

namespace CourseMangmentSystemWeb.Models
{
    public class Student:Super
    {
        public int Id { get; set; }
        public float Gpa { get; set; }
        public int Hours  { get; set; }
    }
}
