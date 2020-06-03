namespace RecipeBook.Models
{
    public class Ingredient : BaseModel
    {
        public string Item { get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; }
    }
}