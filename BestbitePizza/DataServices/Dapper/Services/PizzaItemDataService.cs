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
                string query = "Select id as Id, name As Name, availability_id As AvailabilityId, category_id As CategoryId, image_name As ImageName From pizza.item";
                
                return await _dataContext.GetAll<Item>(query);
            }
            catch (Exception ex)
            {
                return items;
            }
        }

       

    }
}
