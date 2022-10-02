using System.ComponentModel.DataAnnotations;

namespace CourseMangmentSystemWeb.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
