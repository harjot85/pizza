namespace BestbitePizza.Models
{
    public class MenuItemViewModel
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string? ImageName { get; set; }
        public int CategoryId { get; set; }
        public int CategoryName { get; set; }
        public int AvailabilityId { get; set; }
        public int AvailabilityName { get; set; }

        public List<Ingredient> Ingredients { get; set;}

        // For Small/Medium/Large 
        public List<ItemPrice> ItemPrices { get; set; }

    }
}
