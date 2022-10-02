using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseMangmentSystemWeb.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        [Required]
        public string Name{ get; set; }
        public string Description{ get; set; }
        [Required]
        public int  Hours { get; set; }
        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
        public Department Department{ get; set; }
        [ForeignKey(nameof(Instractor))]
        [Required]
        public int InstractorId { get; set; }
        public virtual Instructor? Instractor { get; set; }
    }
}
