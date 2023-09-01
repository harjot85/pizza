using BestbitePizza.Models;
using Microsoft.Azure.Cosmos;

namespace BestbitePizza.DataServices.Cosmos.Context
{
    public interface ICosmosRepository
    {
        Task<T> Get<T>(int id);
        Task<List<T>> GetAll<T>();
        Task<T> Add<T>(T entity);
        Task<MenuItem> Delete(int id);
    }
}
