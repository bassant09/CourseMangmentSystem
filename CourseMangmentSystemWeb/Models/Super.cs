namespace CourseMangmentSystemWeb.Models
{
    public class Super
    {
        public string  FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string  Password { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string IdentityCard { get; set; }
        public string Nationality { get; set; }
        public string ProfilePicture{ get; set; }
        public DateTime JoinAt { get; set; }= DateTime.Now;


    }
}
