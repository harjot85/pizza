namespace BestbitePizza.Models.DataModels
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public int AvailabilityId { get; set; }
    }
}
