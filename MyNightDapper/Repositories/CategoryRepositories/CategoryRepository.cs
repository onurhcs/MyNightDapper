using Dapper;
using MyNightDapper.Context;
using MyNightDapper.Dtos.CategoryDtos;

namespace MyNightDapper.Repositories.CategoryRepositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DapperContext _context;

        public CategoryRepository(DapperContext context)
        {
            _context = context; // Hata: Değişken doğru atanmadığı için düzeltildi.
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            string query = "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)";

            var parameters = new DynamicParameters();
            parameters.Add("@CategoryName", createCategoryDto.CategoryName); // Hata: Static sınıf üzerinden erişim kaldırıldı.

            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            string query = "DELETE FROM Categories WHERE CategoryId = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "SELECT CategoryId, CategoryName FROM Categories";

            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<ResultCategoryDto>(query);

            return result.ToList();
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id)
        {
            string query = "SELECT CategoryId, CategoryName FROM Categories WHERE CategoryId = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query, parameters);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            string query = "UPDATE Categories SET CategoryName = @CategoryName WHERE CategoryId = @CategoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryName", updateCategoryDto.CategoryName);
            parameters.Add("@CategoryId", updateCategoryDto.CategoryId);

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
