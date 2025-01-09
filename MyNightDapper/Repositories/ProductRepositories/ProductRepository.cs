using MyNightDapper.Context;
using MyNightDapper.Dtos.ProductDtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace MyNightDapper.Repositories.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperContext _context;

        public ProductRepository(DapperContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Yeni bir ürün oluşturur.
        /// </summary>
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var query = @"
                INSERT INTO Products (ProductName, ProductStock, ProductPrice, CategoryId) 
                VALUES (@ProductName, @ProductStock, @ProductPrice, @CategoryId)";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, createProductDto);
            }
        }

        /// <summary>
        /// Belirtilen ID'ye sahip ürünü siler.
        /// </summary>
        public async Task DeleteProductAsync(int id)
        {
            var query = "DELETE FROM Products WHERE ProductId = @Id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        /// <summary>
        /// Tüm ürünleri getirir.
        /// </summary>
        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            var query = "SELECT * FROM Products";

            using (var connection = _context.CreateConnection())
            {
                var products = await connection.QueryAsync<ResultProductDto>(query);
                return products.AsList();
            }
        }

        /// <summary>
        /// Belirtilen ID'ye sahip ürünü getirir.
        /// </summary>
        public async Task<GetByIdProductDto> GetByIdProductAsync(int id)
        {
            var query = "SELECT * FROM Products WHERE ProductId = @Id";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<GetByIdProductDto>(query, new { Id = id });
            }
        }

        /// <summary>
        /// Bir ürünü günceller.
        /// </summary>
        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var query = @"
                UPDATE Products 
                SET ProductName = @ProductName, 
                    ProductStock = @ProductStock, 
                    ProductPrice = @ProductPrice, 
                    CategoryId = @CategoryId
                WHERE ProductId = @ProductId";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, updateProductDto);
            }
        }
    }
}
