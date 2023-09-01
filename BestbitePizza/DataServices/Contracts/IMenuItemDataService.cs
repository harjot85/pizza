using BestbitePizza.Models;

namespace BestbitePizza.DataServices.Contracts
{
    public interface IMenuItemDataService
    {
        Task<MenuItem> GetPizzaItem(int id);
        Task<List<MenuItem>> GetPizzaItems();

        Task<MenuItem> AddPizzaItem(MenuItem menuItem);
        Task<MenuItem> AddPizzaItems(List<MenuItem> menuItems);

        Task<MenuItem> UpdatePizzaItem(MenuItem menuItem);
        Task<MenuItem> UpdatePizzaItems(List<MenuItem> menuItems);

        Task<MenuItem> DeletePizzaItem(int id);

        Task<List<MenuItem>> GetDeals();
    }
}
