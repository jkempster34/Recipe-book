using System;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Models
{
    public class Comment : BaseEntity
    {
        [DataType(DataType.Date)]
        public DateTime DatePosted { get; set; }
        public string Text { get; set; }

        // Navigation properties
        public Author Author { get; set; }
        public Recipe Recipe { get; set; }
    }
}