﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Models
{
    public class Recipe : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatePosted { get; set; }
        [Required]
        public string Photo { get; set; }
        public float Rating { get; set; }
        public Course Course { get; set; }

        // Foreign key
        public int? AuthorId { get; set; }

        // Navigation properties
        public IEnumerable<Instruction> Instructions { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public Author Author { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<CategoryRecipe> CategoryRecipes { get; set; }
    }
}
