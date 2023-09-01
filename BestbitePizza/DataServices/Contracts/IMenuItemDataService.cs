using BestbitePizza.Models;

namespace BestbitePizza.DataServices.Contracts
{
    public interface IMenuItemDataService : IRepository
    {
        Task<MenuItem> UpdateMenuItem(MenuItem menuItem);
        Task<MenuItem> UpdateMenuItems(List<MenuItem> menuItems);

        Task<List<MenuItem>> GetDeals();
    }
}
