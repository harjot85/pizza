using BestbitePizza.Models;

namespace BestbitePizza.DataServices.Dapper
{
    public class PizzaItemDataService: IPizzaItemDataService
    {
        public List<Item> GetPizzaItems()
        {
            List<Item> items = new();
            try 
            {
                return new List<Item>() { new Item() { Name = "Potato Pizza", AvailabilityId = 1, CategoryId = 1, Id = 1 } };

            } 
            catch (Exception ex)
            {
                return items;
            }
        }
        
    }
}
