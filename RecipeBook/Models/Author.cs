using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBook.Models
{
    public class Author : BaseModel
    {
        public string IdentityGuid { get; set; }

        public ICollection<Recipe> Recipes { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
