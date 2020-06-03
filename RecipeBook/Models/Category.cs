using System.Collections.Generic;

namespace RecipeBook.Models
{
    public class Category : BaseModel
    {
        public string CategoryName { get; set; }

        public ICollection<CategoryRecipe> CategoryRecipes { get; set; }
    }
}