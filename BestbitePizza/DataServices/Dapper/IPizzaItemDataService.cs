using BestbitePizza.Models;

namespace BestbitePizza.DataServices.Dapper
{
    public interface IPizzaItemDataService
    {
        List<Item> GetPizzaItems();
    }
}
