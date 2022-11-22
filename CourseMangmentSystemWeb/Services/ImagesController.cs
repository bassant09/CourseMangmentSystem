using Microsoft.AspNetCore.Mvc;

namespace CourseMangmentSystemWeb.Services
{
    public class ImagesController : Controller
    {
        public static string UploadImage(IWebHostEnvironment environment, IFormFile imageFile)
        {
           // Console.WriteLine("lol"); 
            Guid guid = Guid.NewGuid();
            string ext = Path.GetExtension(imageFile.FileName);
            string newFileName = guid.ToString() + imageFile.FileName;
            var newPath = Path.Combine(environment.WebRootPath, "images");
            newPath = Path.Combine(newPath, newFileName);

            var stream = new FileStream(newPath, FileMode.Create);

            imageFile.CopyTo(stream);

            stream.Close();

            return newFileName;
        }
    }
}
