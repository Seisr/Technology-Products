using System.ComponentModel.DataAnnotations.Schema;
namespace WebApp.Models;
[Table("Customer")]
public class Customer
{
    public byte CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public bool Gender { get; set; }

    public string Address { get; set; } = null!;
}