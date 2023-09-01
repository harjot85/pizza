using BestbitePizza.Models;

namespace BestbitePizza.DataServices.Dapper.Context
{
    public interface IRepository
    {
        Task<T> Get<T>(int id);
        Task<List<T>> GetAll<T>();
        Task<T> Add<T>(T entity);
        Task<MenuItem> Delete(int id);
    }
}
