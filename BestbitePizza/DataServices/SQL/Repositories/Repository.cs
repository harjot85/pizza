using BestbitePizza.Constants;
using BestbitePizza.DataServices.Contracts;
using BestbitePizza.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BestbitePizza.DataServices.Dapper.Repositories
{
    public class Repository : IRepository
    {
        protected readonly string _connectionString = string.Empty;

        protected readonly IConfiguration _configuration;

        public Repository(IConfiguration configuration)
        {
            _connectionString = _configuration.GetConnectionString("SqlConnection") ?? ERROR.SQL_CONNECTION_NOT_FOUND;
            _configuration = configuration;

        }

        protected IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        public async Task<T> Get<T>(int id)
        {
            string query = "Select I.id as ItemId, I.name As Name, I.availability_id As AvailabilityId, I.category_id As CategoryId, I.image_name As ImageName From pizza.menu_item I";

            using var connection = CreateConnection();

            var dbResult = await connection.QueryFirstAsync<T>(query);

            return dbResult;
        }

        public async Task<List<T>> GetAll<T>()
        {
            string query = "Select I.id as ItemId, I.name As Name, I.availability_id As AvailabilityId, I.category_id As CategoryId, I.image_name As ImageName From pizza.menu_item I";

            using var connection = CreateConnection();

            var dbResult = await connection.QueryAsync<T>(query);

            return dbResult.ToList();
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
