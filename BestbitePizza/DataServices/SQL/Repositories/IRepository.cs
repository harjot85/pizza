using BestbitePizza.Models.DataModels;
using Dapper;

namespace BestbitePizza.DataServices.Dapper.Repositories
{
    public interface IRepository
    {
        Task<T> Get<T>(string query, DynamicParameters parameters);
        Task<IEnumerable<T>> GetAll<T>(string query);
        Task<T> Add<T>(T entity);
        Task<MenuItem> Delete(int id);
    }
}
