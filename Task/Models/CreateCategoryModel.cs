namespace Task.Models;

public class CreateCategoryModel
{
    public required string Name { get; set; }

    public string? Description { get; set; }
}