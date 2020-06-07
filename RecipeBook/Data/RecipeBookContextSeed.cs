using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RecipeBook.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Data
{
    public class RecipeBookContextSeed
    {
        private readonly IWebHostEnvironment _hosting;

        public RecipeBookContextSeed(IWebHostEnvironment hosting)
        {
            _hosting = hosting;
        }

        public async Task SeedAsync(RecipeBookContext recipeBookContext, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!recipeBookContext.Authors.Any())
                {
                    var author = new Author { IdentityUsername = "demouser@recipebook.com" };
                    recipeBookContext.Authors.Add(author);
                    await recipeBookContext.SaveChangesAsync();
                }

                if (!recipeBookContext.Recipes.Any())
                {
                    recipeBookContext.Recipes.AddRange(GetPreconfiguredRecipes());

                    // Needed to explicitly set recipe Id so that relationships can be defined
                    using (var transaction = await recipeBookContext.Database.BeginTransactionAsync())
                    {
                        recipeBookContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Recipes ON");
                        await recipeBookContext.SaveChangesAsync();
                        recipeBookContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Recipes OFF");
                        await transaction.CommitAsync();
                    }
                }

                if (!recipeBookContext.Instructions.Any())
                {
                    recipeBookContext.Instructions.AddRange(GetPreconfiguredInstructions());
                    await recipeBookContext.SaveChangesAsync();
                }

                if (!recipeBookContext.Categories.Any())
                {
                    recipeBookContext.Categories.AddRange(GetPreConfiguredCategories());
                    await recipeBookContext.SaveChangesAsync();
                }

                if (!recipeBookContext.Ingredients.Any())
                {
                    recipeBookContext.Ingredients.AddRange(GetPreConfiguredIngredients());
                    await recipeBookContext.SaveChangesAsync();
                }

                //if(!recipeBookContext.CategoryRec)
            }
            catch (Exception exception)
            {
                var logger = loggerFactory.CreateLogger<RecipeBookContextSeed>();
                logger.LogError($"Failed to seed RecipeBookDb {exception.Message}");
                throw;
            }

        }

        private static IEnumerable<Recipe> GetPreconfiguredRecipes()
        {
            return new List<Recipe>()
            {
                new Recipe {
                    Id = 1,
                    Name = "Sesame seed burger buns",
                    Description = "Homemade Hamburger Buns",
                    DatePosted = DateTime.Today,
                    // TODO: Implement photo saving
                    Photo = "",
                    Rating = 4.5f,
                    Course = Course.Mains
                }
            };
        }

        private IEnumerable<Instruction> GetPreconfiguredInstructions()
        {
            var filePath = Path.Combine(_hosting.ContentRootPath, "Data/recipeInstructions.json");
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<IEnumerable<Instruction>>(json);
        }

        private IEnumerable<Category> GetPreConfiguredCategories()
        {
            return new List<Category>()
            {
                new Category { CategoryName = "Healthy" },
                new Category { CategoryName = "Cakes and baking" },
                new Category { CategoryName = "Cheap and healthy" }
            };
        }

        private IEnumerable<Ingredient> GetPreConfiguredIngredients()
        {
            var filePath = Path.Combine(_hosting.ContentRootPath, "Data/recipeIngredients.json");
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<IEnumerable<Ingredient>>(json);
        }
    }
}