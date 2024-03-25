using Day_3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day_3.Controllers
{
    public class UploadFileController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Upload(int id,IFormFile stdimg)
        {
            String Fname = id.ToString() + "-" + stdimg.FileName.Split("-").Last();
            using (FileStream f1 = new FileStream("wwwroot/images/" + Fname, FileMode.Create))
            {
                stdimg.CopyTo(f1);
            }
            return Content("Photo Added");
        }
    }
}
