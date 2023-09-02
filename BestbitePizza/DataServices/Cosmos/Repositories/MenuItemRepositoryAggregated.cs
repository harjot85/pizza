using BestbitePizza.DataServices.Contracts;
using BestbitePizza.DataServices.Cosmos.Repositories;
using BestbitePizza.Models;
using BestbitePizza.Models.DataModels;

namespace BestbitePizza.DataServices.Cosmos.Services
{
    public class MenuItemRepositoryAggregated : CosmosBaseRepository,  IMenuItemRepositoryAggregated
    {
        
        public MenuItemRepositoryAggregated(IConfiguration configuration) : base(configuration)
        { }

        public async Task<MenuItem> GetMenuItemById(int id)
        {
            string query = "Select I.id as Id, I.name As Name, I.availability_id As AvailabilityId, I.category_id As CategoryId, I.image_name As ImageName FROM Items I Where I.item_id = @Id";

            var dbServiceResult = await Get<MenuItem>(query);

            return dbServiceResult;
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItems()
        {
            string query = "Select I.id as Id, I.name As Name, I.availability_id As AvailabilityId, I.category_id As CategoryId, I.image_name As ImageName FROM Items I";

            var dbServiceResult = await GetAll<MenuItem>(query);

            return dbServiceResult;
        }


        public Task<IEnumerable<Ingredient>> GetAllIngredients()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemPrice>> GetAllItemPrices()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MenuItemIngredient>> GetAllMenuItemIngredients()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vocab>> GetVocabulary()
        {
            throw new NotImplementedException();
        }


        public Task<List<MenuItem>> GetDeals()
        {
            throw new NotImplementedException();
        }

        public Task<MenuItem> UpdateMenuItem(MenuItem menuItem)
        {
            throw new NotImplementedException();
        }

        public Task<MenuItem> UpdateMenuItems(List<MenuItem> menuItems)
        {
            throw new NotImplementedException();
        }
    }
}
