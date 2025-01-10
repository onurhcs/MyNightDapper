using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MyNightDapper.Repositories.SpofityRepositories;
using MyNightDapper.Dtos.SpofityDtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using NuGet.Protocol.Plugins;
using System.Collections;

namespace MyNightDapper.Controllers
{
    public class SpofityChartController : Controller
    {
        private readonly ISpofityRepository _spofityRepository;
        private readonly string _connectionString = "YourDatabaseConnectionStringHere";

        public SpofityChartController(ISpofityRepository spofityRepository)
        {
            _spofityRepository = spofityRepository;
        }

        public async Task<IActionResult> SpotifyChart()
        {
            var spotifyData = await _spofityRepository.GetAllSpotifyAsync();
            return View(spotifyData);
        }

        [HttpGet]
        public IEnumerable<SpotifyDataDto> GetSpotifyData()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT artist_name AS ArtistName, track_name AS TrackName, popularity AS Popularity, genre AS Genre, year AS Year FROM spofitydata";
                return connection.Query<SpotifyDataDto>(query);
            }
        }

        [HttpGet]
        public async Task<IEnumerable<ResultSpotifyDto>> GetPopularityAnalysisAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = @"
            SELECT 
                genre AS Genre,
                COUNT(*) AS SongCount,
                AVG(popularity) AS AveragePopularity
            FROM spofitydata
            GROUP BY genre
            ORDER BY AVG(popularity) DESC";

                return await connection.QueryAsync<ResultSpotifyDto>(query);
            }


        }
        [HttpGet]
        public async Task<IActionResult> GetPopularityAnalysis()
        {
            var spotifyData = await _spofityRepository.GetAllSpotifyAsync();
            return View(spotifyData);
        }
    }
}