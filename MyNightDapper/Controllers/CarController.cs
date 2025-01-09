using Microsoft.AspNetCore.Mvc;
using MyNightDapper.Dtos.CarsDtos;
using MyNightDapper.Repositories;

namespace MyNightDapper.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IActionResult> CarList()
        {
            var cars = await _carRepository.GetAllCarsAsync();
            return View(cars);
        }

        [HttpGet]
        public IActionResult CreateCar()
        {
            return View();
        }
        public async Task<IActionResult> CreateCar(CreateCarsDto createCarDto)
        {
            if (ModelState.IsValid) // DTO doğrulama kontrolü
            {
                await _carRepository.CreateCarAsync(createCarDto);
                return RedirectToAction("CarList");
            }
            return View(createCarDto); // Hatalı giriş durumunda aynı sayfaya geri dön
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carRepository.DeleteCarAsync(id);
            return RedirectToAction("CarList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var car = await _carRepository.GetByIdCarAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarsDto updateCarDto)
        {
            if (ModelState.IsValid)
            {
                await _carRepository.UpdateCarAsync(updateCarDto);
                return RedirectToAction("CarList");
            }
            return View(updateCarDto);
        }
    }
}
