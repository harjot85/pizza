using BestbitePizza.Models;
using Microsoft.Azure.Cosmos;

namespace BestbitePizza.DataServices.Cosmos.Services
{
    public class PizzaItemDataService : IPizzaItemDataService
    {
        private readonly ICosmosDataContext _cosmosDataContext;

        public PizzaItemDataService(ICosmosDataContext cosmosDataContext)
        {
            _cosmosDataContext = cosmosDataContext;
        }
        public async Task<List<Item>> GetPizzaItems()
        {
            List<Item> items = new();
            try
            {
                string query = "Select I.id as Id, I.name As Name, I.availability_id As AvailabilityId, I.category_id As CategoryId, I.image_name As ImageName FROM Items I Where I.item_id = @Id";
                QueryDefinition cosmosQuery = new QueryDefinition(query)
                    .WithParameter("@Id", 5);
                    // .WithParameter("", 0);

                return await _cosmosDataContext.GetAll<Item>(cosmosQuery);
                
            }
            catch (Exception ex)
            {
                return items;
            }
        }
    }
}
