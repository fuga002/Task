namespace Task.Models;

public class UpdateProductModel
{
    public int ProductId { get; set; }
    public  string Name { get; set; }

    public  string Description { get; set; }
    public  decimal Price { get; set; }

}