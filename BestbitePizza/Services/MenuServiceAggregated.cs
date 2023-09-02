using BestbitePizza.DataServices.Contracts;
using BestbitePizza.Models;
using BestbitePizza.Models.DataModels;

namespace BestbitePizza.Services
{
    public class MenuServiceAggregated : IMenuServiceAggregated
    {
        private readonly IMenuItemRepositoryAggregated _menuItemRepository;
        public MenuServiceAggregated(IMenuItemRepositoryAggregated menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public async Task<IEnumerable<CategorizedMenu>> GetCategorizedMenuItems()
        {
            IEnumerable<MenuItem> allMenuItems = await _menuItemRepository.GetAllMenuItems();
            IEnumerable<Ingredient> allIngredients = await _menuItemRepository.GetAllIngredients();
            IEnumerable<ItemPrice> allItemPrices = await _menuItemRepository.GetAllItemPrices();
            IEnumerable<MenuItemIngredient> allMenuItemIngredients = await _menuItemRepository.GetAllMenuItemIngredients();
            IEnumerable<Category> allCategories = await _menuItemRepository.GetAllCategories();
            IEnumerable<Vocab> allvocabulary = await _menuItemRepository.GetVocabulary();

            List<CategorizedMenu> categorizedMenuItems = new();
            List<MenuItemDetail> detailedMenuItems = new();
            
            foreach (var category in allCategories)
            {
                CategorizedMenu categorizedMenu = new()
                { 
                    Id = category.Id,
                    Name = category.Name,
                    ImageName = category.ImageName,
                    AvailabilityId = category.AvailabilityId
                };

                foreach (var item in allMenuItems)
                {
                    IEnumerable<int> ingredientIds = allMenuItemIngredients.Where(m => m.ItemId == item.ItemId).Select(m => m.IngredientId);
                    IEnumerable<ItemPrice> itemPriceIds = allItemPrices.Where(p => p.ItemId == item.ItemId).Select(p => p);

                    MenuItemDetail menuItemDetail = new()
                    {
                        ItemId = item.ItemId,
                        Name = item.Name,
                        ImageName = item.ImageName,
                        AvailabilityId = item.AvailabilityId,
                        CategoryId = item.CategoryId,
                        AvailabilityStatus = allvocabulary.Where(v => v.Id == item.AvailabilityId).Select(v => v.Description).FirstOrDefault(),
                        CategoryName = allCategories.Where(c => c.Id == item.CategoryId).Select(c => c.Name).FirstOrDefault(),
                        ItemPrices = GetItemsWithPriceAndSize(allvocabulary, itemPriceIds),
                        Ingredients = GetItemIngredients(allIngredients, ingredientIds),
                    };

                    detailedMenuItems.Add(menuItemDetail);
                }

                categorizedMenu.MenuItems = detailedMenuItems;

                categorizedMenuItems.Add(categorizedMenu);
            }
                        
            return categorizedMenuItems.OrderBy(c => c.Id);
        }

        private static List<Ingredient> GetItemIngredients(IEnumerable<Ingredient> dbService_Ingredients, IEnumerable<int> IngredientIds)
        {
            List<Ingredient> itemIngredients = new();

            foreach (int id in IngredientIds)
            {
                Ingredient ingredient = new()
                {
                    Id = IngredientIds.Where(i => i.Equals(id)).FirstOrDefault(),
                    Name = dbService_Ingredients.Where(i => i.Id == id).Select(i => i.Name).FirstOrDefault(),
                };
                itemIngredients.Add(ingredient);
            }

            return itemIngredients;
        }

        private static List<ItemPriceAndSize> GetItemsWithPriceAndSize(IEnumerable<Vocab> dbService_vocabulary, IEnumerable<ItemPrice> ItemPriceIds)
        {
            List<ItemPriceAndSize> itemPriceList = new();

            foreach (var i in ItemPriceIds)
            {
                ItemPriceAndSize itemPrice = new()
                {
                    Id = i.Id,
                    Price = i.Price,
                    SizeId = i.SizeId,
                    Size = dbService_vocabulary.Where(v => v.Id == i.SizeId).Select(i => i.Description).FirstOrDefault(),
                };
                itemPriceList.Add(itemPrice);
            };
            return itemPriceList;
        }
    }
}