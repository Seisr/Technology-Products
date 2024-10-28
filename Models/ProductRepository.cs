namespace WebApp.Models;

public class ProductRepository : BaseRepository
{

    public ProductRepository(StoreContext context) : base(context) { }

    public List<Product> GetProducts()
    {
        return context.Product.ToList();
    }

}