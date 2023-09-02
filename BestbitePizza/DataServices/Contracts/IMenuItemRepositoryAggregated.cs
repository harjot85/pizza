using BestbitePizza.Models;
using BestbitePizza.Models.DataModels;

namespace BestbitePizza.DataServices.Contracts
{
    public interface IMenuItemRepositoryAggregated 
    {
        Task<MenuItem> GetMenuItemById(int id);
        Task<IEnumerable<MenuItem>> GetAllMenuItems();

        Task<IEnumerable<Ingredient>> GetAllIngredients();
        Task<IEnumerable<ItemPrice>> GetAllItemPrices();
        Task<IEnumerable<MenuItemIngredient>> GetAllMenuItemIngredients();
        Task<IEnumerable<Category>> GetAllCategories();
        Task<IEnumerable<Vocab>> GetVocabulary();


        Task<MenuItem> UpdateMenuItem(MenuItem menuItem);
        Task<MenuItem> UpdateMenuItems(List<MenuItem> menuItems);

        Task<List<MenuItem>> GetDeals();
    }
}
