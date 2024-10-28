using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
public class WelcomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Simple()
    {
        return View();
    }
}