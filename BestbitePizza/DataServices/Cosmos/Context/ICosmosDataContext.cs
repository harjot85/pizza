using Microsoft.Azure.Cosmos;

namespace BestbitePizza.DataServices.Cosmos.Context
{
    public interface ICosmosDataContext
    {
        Task<T> Get<T>(QueryDefinition query);
        Task<List<T>> GetAll<T>(QueryDefinition query);
    }
}
