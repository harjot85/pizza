namespace BestbitePizza.Models
{
    public class ItemPriceAndSize
    {
        public int Id { get; set; }
        public int SizeId { get; set; } = 0;
        public string Size  { get; set; } = string.Empty;
        public float Price { get; set; }

    }
}
