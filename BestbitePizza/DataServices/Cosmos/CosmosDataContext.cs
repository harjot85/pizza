using BestbitePizza.Constants;
using BestbitePizza.Models;
using Microsoft.Azure.Cosmos;

namespace BestbitePizza.DataServices.Cosmos
{
    public class CosmosDataContext : ICosmosDataContext
    {
        private readonly IConfiguration _configuration;
        private readonly string accountEndpoint;
        private readonly string authKey;

        public CosmosDataContext(IConfiguration configuration)
        {
            _configuration = configuration;
         
            accountEndpoint = _configuration.GetConnectionString("Cosmos-Endpoint") ?? ERROR.ACCOUNT_ENDPOINT_NOT_FOUND;
            authKey = _configuration.GetConnectionString("Cosmos-Key") ?? ERROR.AUTH_KEY_NOT_FOUND;
        }

        public async Task<T> Get<T>(QueryDefinition query)
        {
            try
            {
                CosmosClient client = new(accountEndpoint, authKey);
                Database database = client.GetDatabase(_configuration.GetValue<string>("CosmosResources:Database"));
                Container container = database.GetContainer(_configuration.GetValue<string>("CosmosResources:Container"));

                using FeedIterator<T> feed = container.GetItemQueryIterator<T>(queryDefinition: query);

                FeedResponse<T> response = await feed.ReadNextAsync();

                return response.First();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<T>> GetAll<T>(QueryDefinition query)
        {
            try
            {
                CosmosClient client = new(accountEndpoint, authKey);
                Database database = client.GetDatabase(_configuration.GetValue<string>("CosmosResources:Database"));
                Container container = database.GetContainer(_configuration.GetValue<string>("CosmosResources:Container"));

                using FeedIterator<T> feed = container.GetItemQueryIterator<T>(queryDefinition: query);

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
    }
}
