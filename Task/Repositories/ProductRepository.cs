using Microsoft.EntityFrameworkCore;
using Task.Context;
using Task.Entities;

namespace Task.Repositories;

public class ProductRepository: IProductRepository
{
    private readonly TaskDbContext _dbContext;

    public ProductRepository(TaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Product>> GetAll()
    {
        var products = await _dbContext.Products.ToListAsync();
        return products;
    }

    public async Task<Product> GetById(int id)
    {
        var product = await _dbContext.Products.FirstOrDefaultAsync(c => c.Id == id);
        return product ?? throw new Exception("Product not found");
    }

    public async Task<Product?> GetByName(string name)
    {
        var product = await _dbContext.Products.FirstOrDefaultAsync(c => c.Name == name);
        return product;
    }

    public async System.Threading.Tasks.Task Add(Product product)
    {
        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();

    }

    public async System.Threading.Tasks.Task Update(Product product)
    {
        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task Delete(Product product)
    {
        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync();
    }
}