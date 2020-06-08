using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Models
{
    public class Author : BaseEntity
    {
        // Refers to IdentityUser
        [Required]
        public string IdentityUsername { get; set; }

        // Navigation properties
        public ICollection<Recipe> Recipes { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
