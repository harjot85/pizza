using BestbitePizza.DataServices.Contracts;
using BestbitePizza.DataServices.Dapper.Repositories;
using BestbitePizza.Models;
using BestbitePizza.Models.DataModels;
using Dapper;

namespace BestbitePizza.DataServices.Dapper.Services
{
    public class MenuItemRepositoryAggregated : Repository, IMenuItemRepositoryAggregated
    {
        public MenuItemRepositoryAggregated(IConfiguration configuration) : base(configuration)
        { }

        public async Task<MenuItem> GetMenuItemById(int id)
        {
            string query = @"SELECT [id] As ItemId
                                  ,[name] As Name
                                  ,[category_id] As CategoryId
                                  ,[availability_id] As AvailabilityId
                                  ,[image_name] As ImageName
                              FROM [Projects].[pizza].[menu_item] I 
                                WHERE id = @id";

            DynamicParameters parameters = new();
            parameters.Add("id", id);

            var dbServiceResult = await Get<MenuItem>(query, parameters);

            return dbServiceResult;
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItems()
        {
            string query = @"SELECT [id] As ItemId
                                  ,[name] As Name
                                  ,[category_id] As CategoryId
                                  ,[availability_id] As AvailabilityId
                                  ,[image_name] As ImageName
                              FROM [Projects].[pizza].[menu_item] I";

            var dbServiceResult = await GetAll<MenuItem>(query);

            return dbServiceResult;
        }
      
        public async Task<IEnumerable<Ingredient>> GetAllIngredients()
        {
            string query = @"SELECT [id] As Id
                                  ,[name] As Name
                              FROM [Projects].[pizza].[ingredient]";

            return await GetAll<Ingredient>(query);
        }

        public async Task<IEnumerable<ItemPrice>> GetAllItemPrices()
        {
            string query = @"SELECT [id] As Id
                                  ,[item_id] As ItemId
                                  ,[size_id] As SizeId
                                  ,[price] As Price
                              FROM [Projects].[pizza].[item_price]";

            return await GetAll<ItemPrice>(query);
        }

        public async Task<IEnumerable<MenuItemIngredient>> GetAllMenuItemIngredients()
        {
            string query = @"SELECT [id] As Id
                                  ,[item_id] As ItemId
                                  ,[ingredient_id] As IngredientId
                              FROM [Projects].[pizza].[menu_item_ingredient]";

            return await GetAll<MenuItemIngredient>(query);
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            string query = @"SELECT [id] As Id
                                  ,[name] As Name
                                  ,[image_name] As ImageName
                                  ,[availability_id] As AvailabilityId
                              FROM [Projects].[pizza].[category]";

            return await GetAll<Category>(query);
        }

        public async Task<IEnumerable<Vocab>> GetVocabulary()
        {
            string query = @"SELECT [id] As Id
                                  ,[type] As Type
                                  ,[description] As Description
                              FROM [Projects].[pizza].[vocab]";

            return await GetAll<Vocab>(query);
        }


        public async Task<MenuItem> AddMenuItem(MenuItem menuItem)
        {
            throw new NotImplementedException();
        }

        public async Task<MenuItem> AddMenuItems(List<MenuItem> menuItems)
        {
            throw new NotImplementedException();
        }

        public async Task<MenuItem> DeleteMenuItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MenuItem>> GetDeals()
        {
            throw new NotImplementedException();
        }

        public async Task<MenuItem> UpdateMenuItem(MenuItem menuItem)
        {
            throw new NotImplementedException();
        }

        public async Task<MenuItem> UpdateMenuItems(List<MenuItem> menuItems)
        {
            throw new NotImplementedException();
        }


    }
}
