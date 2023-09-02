using BestbitePizza.DataServices.Contracts;
using BestbitePizza.DataServices.Dapper.Repositories;
using BestbitePizza.Models;
using Dapper;

namespace BestbitePizza.DataServices.Dapper.Services
{
    public class MenuItemRepository : Repository, IMenuItemRepository
    {
        //private readonly IRepository _dataContext;

        public MenuItemRepository(IConfiguration configuration) : base(configuration)
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

        public Task<MenuItem> AddMenuItem(MenuItem menuItem)
        {
            throw new NotImplementedException();
        }

        public Task<MenuItem> AddMenuItems(List<MenuItem> menuItems)
        {
            throw new NotImplementedException();
        }

        public Task<MenuItem> DeleteMenuItem(int id)
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
