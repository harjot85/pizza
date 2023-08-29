using BestbitePizza.Models;

namespace BestbitePizza.DataServices.Dapper.Services
{
    public interface IPizzaItemDataService
    {
        Task<List<Item>> GetPizzaItems();
    }
}
