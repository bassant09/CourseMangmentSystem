using System.ComponentModel.DataAnnotations;

namespace CourseMangmentSystemWeb.Models
{
    public class Admin
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
