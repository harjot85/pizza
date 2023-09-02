using BestbitePizza.Models;

namespace BestbitePizza.DataServices.Contracts
{
    public interface IMenuItemRepository 
    {
        Task<MenuItem> GetMenuItemById(int id);
        Task<IEnumerable<MenuItem>> GetAllMenuItems();

        Task<MenuItem> UpdateMenuItem(MenuItem menuItem);
        Task<MenuItem> UpdateMenuItems(List<MenuItem> menuItems);

        Task<List<MenuItem>> GetDeals();
    }
}
