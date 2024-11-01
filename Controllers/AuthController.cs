using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
namespace WebApp.Controllers;

public class AuthController : Controller
{
    MemberRepository repository;
    public AuthController(MemberRepository repository)
    {
        this.repository = repository;
    }
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterModel obj)
    {
        if (ModelState.IsValid)
        {
            int ret = repository.Add(obj);
            if (ret > 0)
            {
                TempData["Msg"] = "Register Success";
                return RedirectToAction("/auth/login");
            }

        }
        ModelState.AddModelError("Error", "Register Failed");
        return View(obj);
    }
}