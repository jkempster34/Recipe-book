using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Models
{
    public class Category : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }

        // Navigation property
        public ICollection<CategoryRecipe> CategoryRecipes { get; set; }
    }
}