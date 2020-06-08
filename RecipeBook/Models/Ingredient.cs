using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Models
{
    public class Ingredient : BaseEntity
    {
        [Required]
        public string Item { get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; }

        // Foreign key
        public int RecipeId { get; set; }

        // Navigation property
        public Recipe Recipe { get; set; }
    }
}