using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public class ProductRepository : BaseRepository
{

    public ProductRepository(StoreContext context) : base(context) { }

    public List<Product> GetProducts()
    {      // Product join Category
        // return context.Product.Include(p => p.Category).ToList();
        return context.Product.ToList();
    }

}