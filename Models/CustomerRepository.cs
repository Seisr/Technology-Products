namespace WebApp.Models;

public class CustomerRepository
{
    StoreContext context;
    public CustomerRepository(StoreContext ctx)
    {
        this.context = ctx;
    }
    public List<Customer> GetCustomers()
    {
        return context.Customer.ToList();
    }
    public int Add(Customer obj)
    {
        context.Customer.Add(obj);
        return context.SaveChanges();
    }

}