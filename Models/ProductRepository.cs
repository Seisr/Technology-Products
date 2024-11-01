using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public class ProductRepository : BaseRepository
{
    public ProductRepository(StoreContext context) : base(context) { }

    public List<Product> GetProducts()
    {      // Product join Category
        return context.Products.Include(p => p.Category).ToList();
        // return context.Product.ToList();
    }
    public int Add(Product obj)
    {
        context.Products.Add(obj);
        return context.SaveChanges();
    }
    public Product? GetProduct(int id)
    {
        return context.Products.Find(id);
    } // thêm mới ở đây

    public int Edit(Product obj)
    {
        context.Products.Update(obj);
        return context.SaveChanges();
    }
    public int Delete(int id)
    {
        context.Products.Remove(new Product { Id = id });
        return context.SaveChanges();
    }

}