using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;
public class ProductController : Controller
{
    ProductRepository repository;

    public ProductController(ProductRepository repo)
    {
        this.repository = repo;
    }
    public IActionResult Index()
    {
        return View(repository.GetProducts());
    }

}