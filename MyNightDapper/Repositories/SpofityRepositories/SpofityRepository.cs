using Dapper;
using MyNightDapper.Context;
using MyNightDapper.Dtos.SpofityDtos;

namespace MyNightDapper.Repositories.SpofityRepositories
{
    public class SpofityRepository : ISpofityRepository
    {
        private readonly DapperContext _context;

        public SpofityRepository(DapperContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Tüm Spotify verilerini getirir.
        /// </summary>
        public async Task<List<ResultSpotifyDto>> GetAllSpotifyAsync()
        {
            string query = "SELECT * FROM spotify_data";

            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<ResultSpotifyDto>(query);
            return result.AsList();
        }

        /// <summary>
        /// Yeni bir Spotify kaydı oluşturur.
        /// </summary>
        public async Task CreateSpotifyAsync(CreateSpotifyDto createSpotifyDto)
        {
            string query = @"
                INSERT INTO spotify_data 
                (artist_name, track_name, track_id, popularity, year, genre, danceability, energy, [key], loudness, mode, 
                 speechiness, acousticness, instrumentalness, liveness, valence, tempo, duration_ms, time_signature) 
                VALUES 
                (@artist_name, @track_name, @track_id, @popularity, @year, @genre, @danceability, @energy, @key, @loudness, @mode, 
                 @speechiness, @acousticness, @instrumentalness, @liveness, @valence, @tempo, @duration_ms, @time_signature)";

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, createSpotifyDto);
        }

        /// <summary>
        /// Mevcut bir Spotify kaydını günceller.
        /// </summary>
        public async Task UpdateSpotifyAsync(UpdateSpotifyDto updateSpotifyDto)
        {
            string query = @"
                UPDATE spotify_data 
                SET artist_name = @artist_name,
                    track_name = @track_name,
                    track_id = @track_id,
                    popularity = @popularity,
                    year = @year,
                    genre = @genre,
                    danceability = @danceability,
                    energy = @energy,
                    [key] = @key,
                    loudness = @loudness,
                    mode = @mode,
                    speechiness = @speechiness,
                    acousticness = @acousticness,
                    instrumentalness = @instrumentalness,
                    liveness = @liveness,
                    valence = @valence,
                    tempo = @tempo,
                    duration_ms = @duration_ms,
                    time_signature = @time_signature
                WHERE column1 = @column1";

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, updateSpotifyDto);
        }

        /// <summary>
        /// Belirli bir Spotify kaydını siler.
        /// </summary>
        public async Task DeleteSpotifyAsync(int id)
        {
            string query = "DELETE FROM spotify_data WHERE column1 = @id";

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, new { id });
        }

        /// <summary>
        /// Belirli bir Spotify kaydını ID'ye göre getirir.
        /// </summary>
        public async Task<GetByIdSpotifyDto> GetByIdSpotifyAsync(int id)
        {
            string query = "SELECT * FROM spotify_data WHERE column1 = @id";

            using var connection = _context.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<GetByIdSpotifyDto>(query, new { id });
        }
    }
}
