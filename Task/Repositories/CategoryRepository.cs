using Microsoft.EntityFrameworkCore;
using Task.Context;
using Task.Entities;

namespace Task.Repositories;

public class CategoryRepository: ICategoryRepository
{
    private readonly TaskDbContext _dbContext;

    public CategoryRepository(TaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Category>> GetAll()
    {
        var categories = await _dbContext.Categories.ToListAsync();
        return categories;
    }

    public async Task<Category> GetById(int id)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        return category ?? throw new Exception("Category not found");
    }

    public async Task<Category?> GetByName(string name)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Name == name);
        return category;
    }

    public async System.Threading.Tasks.Task Add(Category category)
    {
        _dbContext.Categories.Add(category);
        await _dbContext.SaveChangesAsync();

    }

    public async System.Threading.Tasks.Task Update(Category category)
    {
        _dbContext.Categories.Update(category);
        await _dbContext.SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task Delete(Category category)
    {
        _dbContext.Categories.Remove(category);
        await _dbContext.SaveChangesAsync();
    }
}