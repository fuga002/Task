using System.ComponentModel.DataAnnotations;

namespace Task.Entities;

public class Category
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }
    public DateTime CreateDateTime { get; set; } = DateTime.Now;

    public virtual List<Product> Products { get; set; }

}