using Microsoft.Azure.Cosmos;

namespace BestbitePizza.DataServices
{
    public interface ICosmosDataContext
    {
        Task<T> Get<T>(QueryDefinition query);
        Task<List<T>> GetAll<T>(QueryDefinition query);
    }
}
