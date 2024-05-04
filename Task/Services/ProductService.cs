using Task.Entities;
using Task.Extensions;
using Task.Models;
using Task.Repositories;

namespace Task.Services;

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProductDto>?> GetAllProducts()
    {
        var products = await _repository.GetAll();
        return ConvertExtensions.ConvertToListDto(products);
    }

    public async Task<ProductDto> GetProductById(int id)
    {
        var product = await _repository.GetById(id);
        return product.ConvertToDto();
    }

    public async Task<ProductDto> AddProduct(CreateProductModel model)
    {
        var check = await IsExist(model.Name);
        if (!check)
            throw new Exception("It is already exist");
        var product = new Product()
        {
            Name = model.Name,
            Description = model.Description!,
            Price = model.Price,
            CategoryId = model.CategoryId
        };
        await _repository.Add(product);
        return product.ConvertToDto();
    }

    public async Task<ProductDto> UpdateProduct(UpdateProductModel model)
    {
        var check = await IsExist(model.Name);
        if (!check)
            throw new Exception("It is already exist so you cannot change to this name");
        var product = await _repository.GetById(model.ProductId);
        if(!string.IsNullOrEmpty(model.Name))
            model.Name = model.Name;
        if (!string.IsNullOrEmpty(model.Description))
            product.Description = model.Description;
        if (model.Price != default)
            product.Price = model.Price;
        await _repository.Update(product);
        return product.ConvertToDto();
    }

    public async Task<string> DeleteProduct(int productId)
    {
        var product = await _repository.GetById(productId);
        await _repository.Delete(product);
        return $"{product.Name} product is deleted";
    }

    async Task<bool> IsExist(string name)
    {
        var product = await _repository.GetByName(name);
        return product is null;
    }
}