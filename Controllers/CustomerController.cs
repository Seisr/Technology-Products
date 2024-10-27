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
}