using Microsoft.Data.SqlClient;
using System.Data;

namespace MyNightDapper.Context
{
    public class DapperContext
    {

        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("connectionkey");

        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        //private readonly IConfiguration _configuration;
        //private readonly string _connectionString;

        //public DapperContext(IConfiguration configuration)
        //{
        //    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        //    _connectionString = _configuration.GetConnectionString("connectionkey")
        //                        ?? throw new InvalidOperationException("Connection string 'connectionkey' is not found in the configuration.");
        //}

        //public IDbConnection CreateConnection()
        //{
        //    var connection = new SqlConnection(_connectionString);
        //    try
        //    {
        //        connection.Open(); // Bağlantıyı test etmek için açmayı deneyebilirsin.
        //    }
        //    catch (SqlException ex)
        //    {
        //        // Hata durumunda loglama mekanizması kullanılabilir.
        //        throw new InvalidOperationException("Veritabanı bağlantısı başarısız oldu.", ex);
        //    }
        //    return connection;
        //}
    }
}