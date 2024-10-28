using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class CustomerController : Controller
{
    CustomerRepository repository;
    public CustomerController(CustomerRepository repo)
    {
        this.repository = repo;

    }
    public IActionResult Index()
    {
        return View(repository.GetCustomers());
    }

    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(Customer obj)
    {
        int ret = repository.Add(obj);
        if (ret > 0)
        {
            return Redirect("/customer");
        }
        return View(obj);
    }
}