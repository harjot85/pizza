using BestbitePizza.Constants;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BestbitePizza.DataServices.Dapper.Context
{
    public class DataContext : IDataContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString = string.Empty;
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection") ?? ERROR.SQL_CONNECTION_NOT_FOUND;
        }
        private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        public async Task<List<T>> GetAll<T>(string query)
        {
            using var connection = CreateConnection();
            var dbResult = await connection.QueryAsync<T>(query);

            return dbResult.ToList();
        }

        public async Task<T> Get<T>(string query)
        {
            using var connection = CreateConnection();
            var dbResult = await connection.QueryFirstAsync<T>(query);

            return dbResult;
        }
    }
}
