using Microsoft.AspNetCore.Mvc;
using MyNightDapper.Dtos.SpofityDtos;
using MyNightDapper.Repositories.SpofityRepositories;

namespace MyNightDapper.Controllers
{
    public class SpofityController : Controller
    {
        private readonly ISpofityRepository _spofityRepository;

        public SpofityController(ISpofityRepository spofityRepository)
        {
            _spofityRepository = spofityRepository;
        }

        public async Task<IActionResult> SpotifyList(int page = 1, int pageSize = 20)
        {
            // Toplam veri
            var spotifyData = await _spofityRepository.GetAllSpotifyAsync();

            // Sayfalama işlemi
            var paginatedData = spotifyData
                .Skip((page - 1) * pageSize) // Önceki sayfaları atla
                .Take(pageSize) // Belirtilen sayfa boyutunu al
                .ToList();

            // ViewData ile toplam sayfa sayısını gönder
            ViewData["TotalPages"] = (int)Math.Ceiling((double)spotifyData.Count() / pageSize);
            ViewData["CurrentPage"] = page;

            return View(paginatedData);
        }



        [HttpGet]
        public IActionResult CreateSpotify()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSpotify(CreateSpotifyDto createSpotifyDto)
        {
            if (ModelState.IsValid) // DTO doğrulama kontrolü
            {
                await _spofityRepository.CreateSpotifyAsync(createSpotifyDto);
                return RedirectToAction("SpotifyList");
            }
            return View(createSpotifyDto); // Hatalı giriş durumunda aynı sayfaya geri dön
        }
        [HttpPost]
        public async Task<IActionResult> DeleteSpotify(int id)
        {
            await _spofityRepository.DeleteSpotifyAsync(id);
            return RedirectToAction("SpotifyList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateSpotify(int id)
        {
            var spotifyData = await _spofityRepository.GetByIdSpotifyAsync(id);
            if (spotifyData == null)
            {
                return NotFound();
            }
            return View(spotifyData);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSpotify(UpdateSpotifyDto updateSpotifyDto)
        {
            if (ModelState.IsValid)
            {
                await _spofityRepository.UpdateSpotifyAsync(updateSpotifyDto);
                return RedirectToAction("SpotifyList");
            }
            return View(updateSpotifyDto);
        }
    }
}
