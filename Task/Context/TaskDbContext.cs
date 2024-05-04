using Microsoft.EntityFrameworkCore;
using Task.Entities;

namespace Task.Context;

public class TaskDbContext:DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}