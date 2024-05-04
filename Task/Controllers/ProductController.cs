using Microsoft.AspNetCore.Mvc;
using Task.Models;
using Task.Services;

namespace Task.Controllers
{
    public class ProductController : Controller
    {

        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProducts();
            return View(products);
        }

        public async Task<IActionResult> GetProduct(int productId)
        {
            var product = await _productService.GetProductById(productId);

            return View(product);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(CreateProductModel model)
        {
            try
            {
                await _productService.AddProduct(model);
                return RedirectToAction("Index", "Product");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View();
            }
        }


        public async Task<IActionResult> Update(int productId)
        {
            try
            {
                var product = await _productService.GetProductById(productId);
                var productViewModel = new UpdateProductModel()
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Description = product.Description
                };

                return View(productViewModel);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                await _productService.UpdateProduct(model);

                return RedirectToAction("Index", "Product");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View();
            }
        }


        public async Task<IActionResult> Delete(int productId)
        {
            try
            {
                var product = await _productService.GetProductById(productId);

                return View(product);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.DeleteProduct(id);

            return RedirectToAction("Index", "Product");
        }
    }
}
