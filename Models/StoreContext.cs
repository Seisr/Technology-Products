using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models;

[Table("Category")]
public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options) { } //constructor
    public DbSet<Category> Category { get; set; } = null!;
    public DbSet<Customer> Customer { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Member> Members { get; set; } = null!;
}