using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository repository;
        public CategoryController(CategoryRepository repo)
        {
            this.repository = repo;
        }
        public IActionResult Index()
        {
            return View(repository.GetCategories()); // return all categories
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category obj)
        {
            int ret = repository.Add(obj);
            if (ret > 0)
            {
                return Redirect("/category");
            }
            return View();
        }

    }
}