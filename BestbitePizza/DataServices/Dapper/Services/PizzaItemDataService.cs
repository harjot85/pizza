using BestbitePizza.Models;

namespace BestbitePizza.DataServices.Dapper.Services
{
    public class PizzaItemDataService : IPizzaItemDataService
    {
        private readonly IDataContext _dataContext;

        public PizzaItemDataService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Item>> GetPizzaItems()
        {
            List<Item> items = new();
            try
            {
                string query = "Select I.id as Id, I.name As Name, I.availability_id As AvailabilityId, I.category_id As CategoryId, I.image_name As ImageName From pizza.item I";
                
                return await _dataContext.GetAll<Item>(query);
            }
            catch (Exception ex)
            {
                return items;
            }
        }
    }
}
