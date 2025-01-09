using MyNightDapper.Dtos.SpofityDtos;

namespace MyNightDapper.Repositories.SpofityRepositories
{
    public interface ISpofityRepository
    {
        /// <summary>
        /// Tüm Spotify verilerini getirir.
        /// </summary>
        Task<List<ResultSpotifyDto>> GetAllSpotifyAsync();

        /// <summary>
        /// Yeni bir Spotify kaydı oluşturur.
        /// </summary>
        Task CreateSpotifyAsync(CreateSpotifyDto createSpotifyDto);

        /// <summary>
        /// Mevcut bir Spotify kaydını günceller.
        /// </summary>
        Task UpdateSpotifyAsync(UpdateSpotifyDto updateSpotifyDto);

        /// <summary>
        /// Belirli bir Spotify kaydını siler.
        /// </summary>
        Task DeleteSpotifyAsync(int id);

        /// <summary>
        /// Belirli bir Spotify kaydını ID'ye göre getirir.
        /// </summary>
        Task<GetByIdSpotifyDto> GetByIdSpotifyAsync(int id);
    }
}
