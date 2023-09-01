using BestbitePizza.Models;
using BestbitePizza.DataServices.Contracts;
using BestbitePizza.DataServices.Dapper.Context;
using System.Data.SqlClient;
using System.Data;
using BestbitePizza.Constants;

namespace BestbitePizza.DataServices.Dapper.Services
{
    public class MenuItemDataService : Repository, IMenuItemDataService
    {
        //private readonly IRepository _dataContext;

        public MenuItemDataService(IConfiguration configuration) : base(configuration)
        { }

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
