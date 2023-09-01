using BestbitePizza.DataServices.Contracts;
using BestbitePizza.DataServices.Cosmos.Context;
using BestbitePizza.Models;
using Microsoft.Azure.Cosmos;

namespace BestbitePizza.DataServices.Cosmos.Services
{
    public class MenuItemDataService : CosmosRepository,  IMenuItemDataService
    {
        
        public MenuItemDataService(IConfiguration configuration) : base(configuration)
        { }

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
