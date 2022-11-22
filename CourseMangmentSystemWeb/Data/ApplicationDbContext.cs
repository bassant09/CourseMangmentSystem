using CourseMangmentSystemWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseMangmentSystemWeb.Data
{
    public class ApplicationDbContext:DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>().HasKey(x => new { x.StudentId, x.CourseId });
            modelBuilder.Entity<RequestCourse>().HasKey(x => new { x.StudentId, x.CourseId});
        }
        
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<RequestCourse> RequestCourses { get; set; }
        public DbSet<CourseTask> Tasks { get; set; }


    }
}
