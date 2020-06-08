namespace RecipeBook.Models
{
    public class CategoryRecipe
    {
        // Foreign keys
        public int CategoryId { get; set; }
        public int RecipeId { get; set; }

        // Navigation properties
        public Category Category { get; set; }
        public Recipe Recipe { get; set; }
    }
}
