﻿namespace Task.Models;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedDate { get; set; }

    public int CategoryId { get; set; }
}