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
    public Category? GetCategory(byte id)
    {
        return context.Category.Find(id);
    }
    public int Edit(Category obj)
    {
        context.Category.Update(obj);
        return context.SaveChanges();
    }

    public int Delete(byte id)
    {
        context.Category.Remove(new Category { CategoryId = id });
        return context.SaveChanges();
    }

}