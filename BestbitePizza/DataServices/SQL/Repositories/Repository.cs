using BestbitePizza.Constants;
using BestbitePizza.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BestbitePizza.DataServices.Dapper.Repositories
{
    public class Repository : IRepository
    {
        private string _connectionString = string.Empty;
        private readonly IConfiguration _configuration;

        public Repository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            _connectionString = _configuration.GetConnectionString("SqlConnection") ?? ERROR.SQL_CONNECTION_NOT_FOUND;
            return new SqlConnection(_connectionString);
        }

        public async Task<T> Get<T>(string query, DynamicParameters parameters)
        {
            using var connection = CreateConnection();
            return await connection.QueryFirstAsync<T>(query, parameters);
        }

        public async Task<IEnumerable<T>> GetAll<T>(string query)
        {
            using var connection = CreateConnection();
            var dbResult = await connection.QueryAsync<T>(query);

            return dbResult.AsEnumerable();
        }


        public Task<T> Add<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<MenuItem> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
