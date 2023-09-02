using BestbitePizza.Models.DataModels;

namespace BestbitePizza.DataServices.Cosmos.Repositories
{
    public interface ICosmosBaseRepository
    {
        Task<T> Get<T>(string query);
        Task<IEnumerable<T>> GetAll<T>(string query);
        Task<T> Add<T>(T entity);
        Task<MenuItem> Delete(int id);
    }
}
