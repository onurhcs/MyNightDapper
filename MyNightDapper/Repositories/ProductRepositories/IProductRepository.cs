using MyNightDapper.Dtos.ProductDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyNightDapper.Repositories.ProductRepositories
{
    /// <summary>
    /// Ürün işlemlerini yöneten arayüz.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Tüm ürünleri getirir.
        /// </summary>
        Task<List<ResultProductDto>> GetAllProductsAsync();

        /// <summary>
        /// Yeni bir ürün oluşturur.
        /// </summary>
        /// <param name="createProductDto">Ürün oluşturmak için gerekli DTO.</param>
        Task CreateProductAsync(CreateProductDto createProductDto);

        /// <summary>
        /// Bir ürünü günceller.
        /// </summary>
        /// <param name="updateProductDto">Ürün güncellemek için gerekli DTO.</param>
        Task UpdateProductAsync(UpdateProductDto updateProductDto);

        /// <summary>
        /// Belirtilen ID'ye sahip ürünü siler.
        /// </summary>
        /// <param name="id">Silinecek ürün ID'si.</param>
        Task DeleteProductAsync(int id);

        /// <summary>
        /// Belirtilen ID'ye sahip ürünü getirir.
        /// </summary>
        /// <param name="id">Getirilecek ürün ID'si.</param>
        Task<GetByIdProductDto> GetByIdProductAsync(int id);
    }
}
