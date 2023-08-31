using BestbitePizza.Models;

namespace BestbitePizza.DataServices.Cosmos.Services
{
    public interface IPizzaItemDataService
    {
        Task<List<Item>> GetPizzaItems();
    }
}
