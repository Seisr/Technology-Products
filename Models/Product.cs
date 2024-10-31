using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models;

[Table("Product")]
public class Product
{
    [Column("ProductId")]
    public int Id { get; set; }
    [Column("ProductName")]
    public string Name { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public byte CategoryId { get; set; }
    public Category? Category { get; set; }
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public short Quantity { get; set; }
    public string Unit { get; set; } = null!;



}