using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.Controllers;

public class UploadController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Simple()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Simple(IFormFile f)
    {
        if (f != null)
        {
            //Naive
            string ext = Path.GetExtension(f.FileName);
            string fileName = Helper.RandomString(32 - ext.Length) + ext;

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", f.FileName);
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                f.CopyTo(stream);
            }
            return Redirect("/upload");
        }
        return View();

    }
    public IActionResult Multiple()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Multiple(IFormFile[] af)
    {
        if (af != null && af.Length > 0)
        {
            //Naive
            string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            foreach (IFormFile f in af)
            {
                string ext = Path.GetExtension(f.FileName);
                string fileName = Helper.RandomString(32 - ext.Length) + ext;

                string path = Path.Combine(root, fileName);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    f.CopyTo(stream);
                }
            }
            return Redirect("/upload");
        }
        return View();
    }
}