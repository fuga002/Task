using Task.Entities;

namespace Task.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAll();
    Task<Product> GetById(int id);
    Task<Product?> GetByName(string name);
    System.Threading.Tasks.Task Add(Product product);
    System.Threading.Tasks.Task Update(Product product);
    System.Threading.Tasks.Task Delete(Product product);
}