namespace BestbitePizza.Models.DataModels
{
    public class MenuItem
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string? ImageName { get; set; }
        public int CategoryId { get; set; }
        public int AvailabilityId { get; set; }
    }
}
