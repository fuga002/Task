using Task.Entities;
using Task.Models;

namespace Task.Extensions;

public static class ConvertExtensions
{
    public static CategoryDto ConvertToDto(this Category category)
    {
        return new CategoryDto()
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            Products = ConvertToListDto(category.Products),
            CreateDateTime = category.CreateDateTime
        };
    }

    public static List<CategoryDto>? ConvertToListDto( List<Category> categories)
    {
        if (categories == null || categories.Count == 0) return null;
        var DtoS = new List<CategoryDto>();
        foreach (var category in categories)
        {
            DtoS.Add(category.ConvertToDto());
        }
        return DtoS;
    }

    public static ProductDto ConvertToDto(this Product product)
    {
        return new ProductDto()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            CategoryId = product.CategoryId,
            CreatedDate = product.CreatedDate
        };
    }

    public static List<ProductDto>? ConvertToListDto( List<Product>? products)
    {
        if (products == null || products.Count == 0) return null;
        var DtoS = new List<ProductDto>();
        foreach (var product in products)
        {
            DtoS.Add(product.ConvertToDto());
        }
        return DtoS;
    }
}