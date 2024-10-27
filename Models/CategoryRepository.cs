namespace WebApp.Models;

public class CategoryRepository
{
    StoreContext context;
    public CategoryRepository(StoreContext ctx)
    {
        this.context = ctx;
    }
    public List<Category> GetCategories()
    {
        return context.Category.ToList(); //return all categories chạy select * from category
    }

    public int Add(Category obj)
    {
        context.Category.Add(obj);
        return context.SaveChanges();
    }
}