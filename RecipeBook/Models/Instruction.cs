namespace RecipeBook.Models
{
    public class Instruction : BaseEntity
    {
        public int InstructionNumber { get; set; }
        public string InstructionText { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}