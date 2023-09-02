using BestbitePizza.Constants;
using BestbitePizza.Models;
using Microsoft.Azure.Cosmos;

namespace BestbitePizza.DataServices.Cosmos.Repositories
{
    public class CosmosBaseRepository : ICosmosBaseRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string accountEndpoint;
        private readonly string authKey;

        public CosmosBaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;

            accountEndpoint = _configuration.GetConnectionString("Cosmos-Endpoint") ?? ERROR.ACCOUNT_ENDPOINT_NOT_FOUND;
            authKey = _configuration.GetConnectionString("Cosmos-Key") ?? ERROR.AUTH_KEY_NOT_FOUND;
        }

        public async Task<T> Get<T>(string query)
        {
            try
            {
                CosmosClient client = new(accountEndpoint, authKey);
                Database database = client.GetDatabase(_configuration.GetValue<string>("CosmosResources:Database"));
                Container container = database.GetContainer(_configuration.GetValue<string>("CosmosResources:Container"));

                
                QueryDefinition cosmosQuery = new QueryDefinition(query)
                    .WithParameter("@Id", 5);
                // .WithParameter("", 0);

                using FeedIterator<T> feed = container.GetItemQueryIterator<T>(queryDefinition: cosmosQuery);

                FeedResponse<T> response = await feed.ReadNextAsync();

                return response.First();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAll<T>(string query)
        {
            try
            {
                CosmosClient client = new(accountEndpoint, authKey);
                Database database = client.GetDatabase(_configuration.GetValue<string>("CosmosResources:Database"));
                Container container = database.GetContainer(_configuration.GetValue<string>("CosmosResources:Container"));

                QueryDefinition cosmosQuery = new(query);

                using FeedIterator<T> feed = container.GetItemQueryIterator<T>(queryDefinition: cosmosQuery);

                List<T> items = new();
                while (feed.HasMoreResults)
                {
                    FeedResponse<T> response = await feed.ReadNextAsync();
                    items.Add(response.First());
                }

                return items;
            }
            catch (Exception ex)
            {
                throw;
            }
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
