using System.Collections.Generic;

namespace RecipeBook.Models
{
    public class Author : BaseEntity
    {
        // Refers to IdentityUser
        public string IdentityUsername { get; set; }

        // Navigation properties
        public ICollection<Recipe> Recipes { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
