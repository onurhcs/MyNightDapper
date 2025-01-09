using MyNightDapper.Dtos.CarsDtos;
using MyNightDapper.Dtos.CategoryDtos;
using System.Collections.Generic;

public interface ICarRepository
{
 
    Task<List<ResultCarsDto>> GetAllCarsAsync();

 
    Task CreateCarAsync(CreateCarsDto createCarDto);

  
    Task UpdateCarAsync(UpdateCarsDto updateCarDto);

  
    Task DeleteCarAsync(int id);

   
    Task<GetByIdCarsDto> GetByIdCarAsync(int id);
}
