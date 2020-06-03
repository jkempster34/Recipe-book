using Microsoft.EntityFrameworkCore;
using RecipeBook.Models;

namespace RecipeBook.Data
{
    public class RecipeBookContext : DbContext
    {
        public RecipeBookContext(DbContextOptions<RecipeBookContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryRecipe>()
                .HasKey(key => new { key.CategoryId, key.RecipeId });

            modelBuilder.Entity<CategoryRecipe>()
                .HasOne(catRec => catRec.Category)
                .WithMany(category => category.CategoryRecipes)
                .HasForeignKey(catRec => catRec.CategoryId);

            modelBuilder.Entity<CategoryRecipe>()
                .HasOne(catRec => catRec.Recipe)
                .WithMany(recipe => recipe.CategoryRecipes)
                .HasForeignKey(catRec => catRec.RecipeId);
        }

    }
}
