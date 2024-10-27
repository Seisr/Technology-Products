using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models;
public class Category
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public byte CategoryId { get; set; }
    public string CategoryName { get; set; } = null!; //not null


}