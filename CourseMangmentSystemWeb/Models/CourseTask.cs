using System.ComponentModel.DataAnnotations.Schema;

namespace CourseMangmentSystemWeb.Models
{
    public class CourseTask
    {
        public int Id { get; set; }
        public String Content { get; set; }
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public  Course Course { get; set; }
    }
}
