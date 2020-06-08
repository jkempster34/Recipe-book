using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RecipeBook.Data.Constants;
using RecipeBook.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RecipeBook.Data
{
    public static class RecipeBookContextSeed
    {
        public static void Seed(RecipeBookContext recipeBookContext, ILoggerFactory loggerFactory,
            IWebHostEnvironment hostingEnv)
        {
            var logger = loggerFactory.CreateLogger(typeof(RecipeBookContextSeed));

            try
            {
                if (recipeBookContext.Authors.Any())
                {
                    logger.LogInformation("The database has already been seeded");
                    return;
                }

                var author = new Author { IdentityUsername = AuthorizationConstants.DEFAULT_USER_USERNAME };
                recipeBookContext.Authors.Add(author);
                recipeBookContext.SaveChanges();

                var recipe = new Recipe
                {
                    Name = "Sesame seed burger buns",
                    Description = "Homemade Hamburger Buns",
                    DatePosted = DateTime.Today,
                    // TODO: Implement photo saving
                    Photo = "",
                    Rating = 4.5f,
                    Course = Course.Mains,
                    Author = author,
                    AuthorId = author.Id
                };
                recipeBookContext.Recipes.Add(recipe);
                recipeBookContext.SaveChanges();

                var instructions = GetSeedDataFromJson<Instruction>(hostingEnv, path: "Data/SeedData/recipeInstructions.json",
                    logger);
                foreach (var instruction in instructions)
                {
                    instruction.RecipeId = recipe.Id;
                }
                recipeBookContext.Instructions.AddRange(instructions);
                recipeBookContext.SaveChanges();

                var ingredients = GetSeedDataFromJson<Ingredient>(hostingEnv, path: "Data/SeedData/recipeIngredients.json",
                    logger);
                foreach (var ingredient in ingredients)
                {
                    ingredient.RecipeId = recipe.Id;
                }
                recipeBookContext.Ingredients.AddRange(ingredients);
                recipeBookContext.SaveChanges();

                var comments = GetSeedDataFromJson<Comment>(hostingEnv, path: "Data/SeedData/recipeComments.json",
                    logger);
                foreach (var comment in comments)
                {
                    comment.RecipeId = recipe.Id;
                    comment.AuthorId = author.Id;
                    comment.DatePosted = DateTime.Today;
                }
                recipeBookContext.Comments.AddRange(comments);
                recipeBookContext.SaveChanges();

                var categories = new List<Category>()
                {
                    new Category { CategoryName = "Healthy" },
                    new Category { CategoryName = "Cakes and baking" },
                    new Category { CategoryName = "Cheap and healthy" }
                };
                recipeBookContext.Categories.AddRange(categories);
                recipeBookContext.SaveChanges();

                var categoryRecipe = new CategoryRecipe()
                {
                    CategoryId = categories.Single(category => category.CategoryName == "Cakes and baking").Id,
                    RecipeId = recipe.Id
                };
                recipeBookContext.CategoryRecipe.AddRange(categoryRecipe);
                recipeBookContext.SaveChanges();

            }
            catch (Exception exception)
            {
                logger.LogError($"Failed to seed RecipeBookDb {exception.Message}");
                throw;
            }

        }

        private static IEnumerable<T> GetSeedDataFromJson<T>(IWebHostEnvironment hostingEnv, string path,
            ILogger logger)
        {
            try
            {
                var filePath = Path.Combine(hostingEnv.ContentRootPath, path);
                var json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
            }
            catch (Exception exception)
            {
                logger.LogError($"Failed to get data from file {path} with message: {exception}");
                throw;
            }

        }
    }
}