namespace CourseMangmentSystemWeb.Models
{
    public class RequestCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Student Student{ get; set; }
        public Course Course { get; set; }

    }
}
