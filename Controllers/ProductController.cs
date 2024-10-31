using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers;
public class ProductController : Controller
{
    // Naive => repo 1 times?
    ProductRepository repository;
    CategoryRepository categoryRepository;

    public ProductController(ProductRepository repository, CategoryRepository categoryRepository)
    {
        this.repository = repository;
        this.categoryRepository = categoryRepository;
    }

    // public IActionResult Delete(int id)
    // {
    //     return View(repository.GetProduct(id));
    // }


    public IActionResult Add()
    {

        ViewBag.Categories = categoryRepository.GetCategories();
        return View();

    }
    public IActionResult Index()
    {
        return View(repository.GetProducts());
    }
    [HttpPost]
    public IActionResult Add(Product obj, IFormFile f)
    {
        if (f is null)
        {
            ModelState.AddModelError("Error", "Please upload image");
            return View(obj);
        }
        string fileName = Helper.Upload(f, 32);
        obj.IMAGEUrl = fileName;
        int ret = repository.Add(obj);
        if (ret > 0)
        {
            return Redirect("/product");
        }
        return View(obj);
    }
}