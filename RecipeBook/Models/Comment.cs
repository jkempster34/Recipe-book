using System;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Models
{
    public class Comment : BaseModel
    {
        [DataType(DataType.Date)]
        public DateTime DatePosted { get; set; }
        public string Text { get; set; }

        public Author Author { get; set; }
        public Recipe Recipe { get; set; }
    }
}