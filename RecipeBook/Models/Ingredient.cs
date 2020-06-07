namespace RecipeBook.Models
{
    public class Ingredient : BaseEntity
    {
        public string Item { get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; }

        // Navigation properties
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}