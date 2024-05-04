using System.ComponentModel.DataAnnotations;

namespace Task.Entities;

public class Product
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedDate { get; set;} = DateTime.Now;

    public int CategoryId { get; set; }
    public virtual Category? Category { get; set; }
}