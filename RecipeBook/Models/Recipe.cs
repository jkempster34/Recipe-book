using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Models
{
    public class Recipe : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatePosted { get; set; }
        public string Photo { get; set; }
        public float Rating { get; set; }
        public Course Course { get; set; }

        public ICollection<Instruction> Method { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public Author Author { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<CategoryRecipe> CategoryRecipes { get; set; }
    }
}
