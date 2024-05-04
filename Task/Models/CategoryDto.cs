using Task.Entities;

namespace Task.Models;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }
    public DateTime CreateDateTime { get; set; } 

    public List<ProductDto> Products { get; set; }
}