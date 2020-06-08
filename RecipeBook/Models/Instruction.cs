using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Models
{
    public class Instruction : BaseEntity
    {
        public int InstructionNumber { get; set; }
        [Required]
        [StringLength(500)]
        public string InstructionText { get; set; }

        // Foreign key
        public int RecipeId { get; set; }

        // Navigation property
        public Recipe Recipe { get; set; }
    }
}