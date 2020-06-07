using System.Collections.Generic;

namespace RecipeBook.Models
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }

        // Navigation property
        public ICollection<CategoryRecipe> CategoryRecipes { get; set; }
    }
}