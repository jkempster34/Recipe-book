using System;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Models
{
    public class Comment : BaseEntity
    {
        [DataType(DataType.Date)]
        public DateTime DatePosted { get; set; }
        [Required]
        [StringLength(500)]
        public string Text { get; set; }

        // Foreign keys
        public int? AuthorId { get; set; }
        public int RecipeId { get; set; }

        // Navigation properties
        public Author Author { get; set; }
        public Recipe Recipe { get; set; }
    }
}