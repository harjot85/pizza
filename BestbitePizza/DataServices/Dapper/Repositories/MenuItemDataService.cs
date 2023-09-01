﻿using BestbitePizza.Models;
using BestbitePizza.DataServices.Contracts;
using BestbitePizza.DataServices.Dapper.Context;

namespace BestbitePizza.DataServices.Dapper.Services
{
    public class MenuItemDataService : IMenuItemDataService
    {
        private readonly IDataContext _dataContext;

        public MenuItemDataService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<MenuItem> GetPizzaItem(int id)
        {
            try
            {
                string query = "Select I.id as ItemId, I.name As Name, I.availability_id As AvailabilityId, I.category_id As CategoryId, I.image_name As ImageName From pizza.menu_item I";

                return await _dataContext.Get<MenuItem>(query);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<MenuItem>> GetPizzaItems()
        {
            List<MenuItem> items = new();
            try
            {
                string query = "Select I.id as ItemId, I.name As Name, I.availability_id As AvailabilityId, I.category_id As CategoryId, I.image_name As ImageName From pizza.menu_item I";

                return await _dataContext.GetAll<MenuItem>(query);
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
