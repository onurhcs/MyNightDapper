using Microsoft.AspNetCore.Mvc;
using MyNightDapper.Dtos.CategoryDtos;
using MyNightDapper.Repositories.CategoryRepositories;
using System.Threading.Tasks;

namespace MyNightDapper.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        //  Kategori listesini getirir
        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryRepository.GetAllCategoryAsync();
            return View(values);
        }

        //  Kategori oluşturma formunu görüntüler
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        //  Yeni kategori oluşturur
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            if (ModelState.IsValid) // DTO doğrulama kontrolü
            {
                await _categoryRepository.CreateCategoryAsync(createCategoryDto);
                return RedirectToAction("CategoryList");
            }
            return View(createCategoryDto); // Hatalı giriş durumunda aynı sayfaya geri dön
        }

        //  Kategori silme işlemi
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
            return RedirectToAction("CategoryList");
        }

        //  Kategori güncelleme formunu görüntüler
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var values = await _categoryRepository.GetByIdCategoryAsync(id);
            if (values == null)
            {
                return NotFound();
            }
            return View(values);
        }

        //  Kategori güncelleme işlemi
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.UpdateCategoryAsync(updateCategoryDto);
                return RedirectToAction("CategoryList");
            }
            return View(updateCategoryDto);
        }
    }
}
