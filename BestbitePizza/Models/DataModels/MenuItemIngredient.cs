namespace BestbitePizza.Models.DataModels
{
    public class MenuItemIngredient
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int IngredientId { get; set; } = 0;
    }
}
