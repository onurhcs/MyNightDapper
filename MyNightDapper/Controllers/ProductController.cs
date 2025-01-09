using Microsoft.AspNetCore.Mvc;
using MyNightDapper.Dtos.ProductDtos;
using MyNightDapper.Repositories.ProductRepositories;
using System.Threading.Tasks;

namespace MyNightDapper.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> ProductList()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.CreateProductAsync(createProductDto);
                return RedirectToAction("ProductList");
            }
            return View(createProductDto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var product = await _productRepository.GetByIdProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.UpdateProductAsync(updateProductDto);
                return RedirectToAction("ProductList");
            }
            return View(updateProductDto);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productRepository.DeleteProductAsync(id);
            return RedirectToAction("ProductList");
        }
       
        public async Task<IActionResult> DetailsProduct(int id)
        {
            var product = await _productRepository.GetByIdProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
