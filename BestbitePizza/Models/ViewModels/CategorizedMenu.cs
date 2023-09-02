using BestbitePizza.Models.DataModels;

namespace BestbitePizza.Models
{
    public class CategorizedMenu
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public int AvailabilityId { get; set; }
        public int AvailabilityName { get; set; }
        public IEnumerable<MenuItemDetail> MenuItems { get; set; }
    }
}
