using Microsoft.AspNetCore.Mvc;
using Task.Entities;
using Task.Models;
using Task.Services;

namespace Task.Controllers;

public class CategoryController : Controller
{
    private readonly CategoryService _categoryService;

    public CategoryController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.GetAllCategories();
        return View(categories);
    }

    public async Task<IActionResult> GetCategory(int categoryId)
    {
        var category = await _categoryService.GetCategoryById(categoryId);

        return View(category);
    }

    public ActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Add(CreateCategoryModel model)
    {
        try
        {
            await _categoryService.AddCategory(model);
            return RedirectToAction("Index", "Category");
        }
        catch (Exception e)
        {
            ViewBag.ErrorMessage = e.Message;
            return View();
        }
    }


    public async Task<IActionResult> Update(int categoryId)
    {
        try
        {
            var category = await _categoryService.GetCategoryById(categoryId);
            var categoryViewModel = new UpdateCategoryModel()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };

            return View(categoryViewModel);
        }
        catch (Exception e)
        {
            return NotFound();
        }
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateCategoryModel model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _categoryService.UpdateCategory(model);

            return RedirectToAction("Index", "Category");
        }
        catch (Exception e)
        {
            ViewBag.ErrorMessage = e.Message;
            return View();
        }
    }


    public async Task<IActionResult> Delete(int categoryId)
    {
        try
        {
            var category = await _categoryService.GetCategoryById(categoryId);
            var categoryViewModel = new UpdateCategoryModel()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };

            return View(categoryViewModel);
        }
        catch (Exception e)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _categoryService.DeleteCategory(id);

        return RedirectToAction("Index", "Category");
    }
}
