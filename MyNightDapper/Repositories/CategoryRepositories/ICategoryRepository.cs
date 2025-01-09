using MyNightDapper.Dtos.CategoryDtos;

namespace MyNightDapper.Repositories.CategoryRepositories
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Tüm kategorileri getirir.
        /// </summary>
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();

        /// <summary>
        /// Yeni bir kategori oluşturur.
        /// </summary>
        /// <param name="createCategoryDto">Kategori oluşturmak için gerekli DTO.</param>
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);

        /// <summary>
        /// Bir kategoriyi günceller.
        /// </summary>
        /// <param name="updateCategoryDto">Kategori güncellemek için gerekli DTO.</param>
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);

        /// <summary>
        /// Belirtilen ID'ye sahip kategoriyi siler.
        /// </summary>
        /// <param name="id">Silinecek kategori ID'si.</param>
        Task DeleteCategoryAsync(int id);

        /// <summary>
        /// Belirtilen ID'ye sahip kategoriyi getirir.
        /// </summary>
        /// <param name="id">Getirilecek kategori ID'si.</param>
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id);
    }
}
