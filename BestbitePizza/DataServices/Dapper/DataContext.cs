using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BestbitePizza.DataServices.Dapper
{
    public class DataContext : IDataContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString = string.Empty;
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        public async Task<List<T>> GetAll<T>(string query)
        {
            using var connection = CreateConnection();
            var dbResult = await connection.QueryAsync<T>(query);

            return dbResult.ToList();
        }
    }
}
