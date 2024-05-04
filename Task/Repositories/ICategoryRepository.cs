using Task.Entities;

namespace Task.Repositories;

public interface ICategoryRepository
{
    Task<List<Category>> GetAll();
    Task<Category> GetById(int id);
    Task<Category?> GetByName(string name);
    System.Threading.Tasks.Task  Add(Category category);
    System.Threading.Tasks.Task Update (Category category);
    System.Threading.Tasks.Task Delete(Category category);
}