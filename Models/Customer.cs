namespace WebApp.Models;

public class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public bool Gender { get; set; }

    public string Address { get; set; } = null!;
}