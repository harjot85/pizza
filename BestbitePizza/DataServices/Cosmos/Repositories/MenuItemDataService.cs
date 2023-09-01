using BestbitePizza.DataServices.Contracts;
using BestbitePizza.DataServices.Cosmos.Context;
using BestbitePizza.Models;
using Microsoft.Azure.Cosmos;

namespace BestbitePizza.DataServices.Cosmos.Services
{
    public class MenuItemDataService : IMenuItemDataService
    {
        private readonly ICosmosDataContext _cosmosDataContext;

        public MenuItemDataService(ICosmosDataContext cosmosDataContext)
        {
            _cosmosDataContext = cosmosDataContext;
        }

        public Task<MenuItem> GetPizzaItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MenuItem>> GetPizzaItems()
        {
            List<MenuItem> items = new();
            try
            {
                string query = "Select I.id as Id, I.name As Name, I.availability_id As AvailabilityId, I.category_id As CategoryId, I.image_name As ImageName FROM Items I Where I.item_id = @Id";
                QueryDefinition cosmosQuery = new QueryDefinition(query)
                    .WithParameter("@Id", 5);
                // .WithParameter("", 0);

                return await _cosmosDataContext.GetAll<MenuItem>(cosmosQuery);

            }
            catch (Exception ex)
            {
                return items;
            }
        }

        public Task<MenuItem> AddPizzaItem(MenuItem menuItem)
        {
            throw new NotImplementedException();
        }

        public Task<MenuItem> AddPizzaItems(List<MenuItem> menuItems)
        {
            throw new NotImplementedException();
        }

        public Task<MenuItem> DeletePizzaItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MenuItem>> GetDeals()
        {
            throw new NotImplementedException();
        }

        public Task<MenuItem> UpdatePizzaItem(MenuItem menuItem)
        {
            throw new NotImplementedException();
        }

        public Task<MenuItem> UpdatePizzaItems(List<MenuItem> menuItems)
        {
            throw new NotImplementedException();
        }
    }
}
