using BestbitePizza.Models.DataModels;

namespace BestbitePizza.Models
{
    public class MenuItemDetail
    {
        public int ItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ImageName { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; } = string.Empty;
        public int AvailabilityId { get; set; } = 0;
        public string? AvailabilityStatus { get; set; } = string.Empty;
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public IEnumerable<ItemPriceAndSize> ItemPrices { get; set; }
    }
}
