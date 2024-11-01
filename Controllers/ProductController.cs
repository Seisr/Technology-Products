using System.Reflection.Metadata.Ecma335;
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
    [HttpPost]
    public IActionResult Edit(int id, Product obj, IFormFile f)
    {
        if (f != null && !string.IsNullOrEmpty(f.FileName))
        {
            string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

            string path = Path.Combine(root, obj.IMAGEUrl);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            string fileName = Helper.Upload(f, root, 32);
            obj.IMAGEUrl = fileName;
        }
        int ret = repository.Edit(obj);
        if (ret > 0)
        {
            TempData["Msg"] = "Update Success";
            return Redirect("/product");
        }
        // return Edit(id);
        ModelState.AddModelError("Error", "Update Failed");
        ViewBag.Categories = categoryRepository.GetCategories();
        ViewBag.units = new string[] { "Kg", "Gam", "Cái" };
        return View(obj); //obj == repository.GetProduct(id)
    }
    public IActionResult Edit(int id)
    {
        ViewBag.Categories = categoryRepository.GetCategories();

        ViewBag.units = new string[] { "Kg", "Gam", "Cái" };
        return View(repository.GetProduct(id));
    }

    public IActionResult Delete(int id)
    {
        return View(repository.GetProduct(id));
    }
    [HttpPost]
    public IActionResult Delete(int id, string imageUrl)
    {

        int ret = repository.Delete(id);
        if (ret > 0)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageUrl);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            TempData["Msg"] = "Delete Success";
            return Redirect("/product");
        }
        return Delete(id);

    }


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
            // ModelState.AddModelError("Error", "Please upload image");
            // return View(obj);
            return Add();
        }
        string fileName = Helper.Upload(f, 32);
        obj.IMAGEUrl = fileName;
        int ret = repository.Add(obj);
        if (ret > 0)
        {
            // Cái này là 1 Session <=> Cookies --- lưu vào Session
            TempData["Msg"] = "Insert Success";
            return Redirect("/product");
        }
        ModelState.AddModelError("Error", "Insert Failed");
        // return View(obj);
        return Add();
    }


}