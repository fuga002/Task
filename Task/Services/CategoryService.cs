using Task.Entities;
using Task.Extensions;
using Task.Models;
using Task.Repositories;

namespace Task.Services;

public class CategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CategoryDto>?> GetAllCategories()
    {
        var categories = await _repository.GetAll();
        return ConvertExtensions.ConvertToListDto(categories);
    }

    public async Task<CategoryDto> GetCategoryById(int id)
    {
        var category = await _repository.GetById(id);
        return category.ConvertToDto();
    }

    public async Task<CategoryDto> AddCategory(CreateCategoryModel model)
    {
        var check = await IsExist(model.Name);
        if (!check)
            throw new Exception("It is already exist");
        var category = new Category()
        {
            Name = model.Name,
            Description = model.Description!
        };
        await _repository.Add(category);
        return category.ConvertToDto();
    }

    public async Task<CategoryDto> UpdateCategory(UpdateCategoryModel model)
    {
        var check = await IsExist(model.Name);
        if (!check)
            throw new Exception("It is already exist so you cannot change to this name");
        var category = await _repository.GetById(model.Id);
        if (!string.IsNullOrEmpty(model.Name))
            category.Name = model.Name;
        if (!string.IsNullOrEmpty(model.Description))
            category.Description = model.Description;
        await _repository.Update(category);
        return category.ConvertToDto();
    }

    public async Task<string> DeleteCategory(int categoryId)
    {
        var category = await _repository.GetById(categoryId);
        await _repository.Delete(category);
        return $"{category.Name} category is deleted";
    }

    async Task<bool> IsExist(string name)
    {
        var category =  await _repository.GetByName(name);
        return category is null;
    }
}