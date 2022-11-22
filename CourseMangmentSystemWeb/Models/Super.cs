using Microsoft.Build.Framework;

namespace CourseMangmentSystemWeb.Models
{
    public class Super
    {
        [Required]
        public string  FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string  Password { get; set; }
        public string? Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? IdentityCard { get; set; }
        public string? Nationality { get; set; }
        public string? ProfilePicture{ get; set; }
        public DateTime JoinAt { get; set; }= DateTime.Now;

    }
}
