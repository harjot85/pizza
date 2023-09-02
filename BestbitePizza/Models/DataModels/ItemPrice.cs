namespace BestbitePizza.Models.DataModels
{
    public class ItemPrice
    {
        public int Id { get; set; }
        public int ItemId { get; set; } = 0;
        public int SizeId { get; set; } = 0;
        public float Price { get; set; }
    }
}
