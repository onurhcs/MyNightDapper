using Dapper;
using MyNightDapper.Context;
using MyNightDapper.Dtos.CarsDtos;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MyNightDapper.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly DapperContext _context;

        public CarRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<ResultCarsDto>> GetAllCarsAsync()
        {
            string query = "SELECT * FROM Cars";

            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<ResultCarsDto>(query);
            return result.AsList();
        }

        public async Task CreateCarAsync(CreateCarsDto createCarDto)
        {
            string query = @"
                INSERT INTO Cars 
                (Company_Names, Cars_Names, Engines, CC_Battery_Capacity, HorsePower, Total_Speed, 
                 Performance_0_100_KM_H, Cars_Prices, Fuel_Types, Seats, Torque) 
                VALUES 
                (@Company_Names, @Cars_Names, @Engines, @CC_Battery_Capacity, @HorsePower, @Total_Speed, 
                 @Performance_0_100_KM_H, @Cars_Prices, @Fuel_Types, @Seats, @Torque)";

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, createCarDto);
        }


        public async Task UpdateCarAsync(UpdateCarsDto updateCarDto)
        {
            string query = @"
                UPDATE Cars 
                SET Company_Names = @Company_Names,
                    Cars_Names = @Cars_Names,
                    Engines = @Engines,
                    CC_Battery_Capacity = @CC_Battery_Capacity,
                    HorsePower = @HorsePower,
                    Total_Speed = @Total_Speed,
                    Performance_0_100_KM_H = @Performance_0_100_KM_H,
                    Cars_Prices = @Cars_Prices,
                    Fuel_Types = @Fuel_Types,
                    Seats = @Seats,
                    Torque = @Torque
                WHERE CarsId = @CarsId";

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, updateCarDto);
        }

        public async Task DeleteCarAsync(int id)
        {
            string query = "DELETE FROM Cars WHERE CarsId = @CarsId";

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, new { CarsId = id });
        }


        public async Task<GetByIdCarsDto> GetByIdCarAsync(int id)
        {
            string query = "SELECT * FROM Cars WHERE CarsId = @CarsId";

            using var connection = _context.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<GetByIdCarsDto>(query, new { CarsId = id });
        }
    }
}
