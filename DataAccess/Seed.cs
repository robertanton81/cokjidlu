using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Domain;

namespace DataAccess
{
    public class Seed
    {
        public static void SeedData(DataContext ctx)
        {
            // debug for the seed in case of any issues here
            /*
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                System.Diagnostics.Debugger.Launch();
            }
            */

            if (!ctx.Recipes.Any())
            {
                Console.WriteLine("start importing recipes");
                List<List<List<RecipeWebScraper>>> scraperRecipes = new List<List<List<RecipeWebScraper>>>();
                WebScraper ws = new WebScraper();
                ws.KucharkaProDceru = true;
                scraperRecipes = ws.getRecipes();

                List<Recipe> recipesDB = new List<Recipe>();
                List<Ingredient> ingredientsDB = new List<Ingredient>();

                foreach (var wholeScraper in scraperRecipes)
                {
                    foreach (var singleScraper in wholeScraper)
                    {
                        foreach (var recipe in singleScraper)
                        {
                            recipesDB.Add(
                                new Recipe {
                                    Id = new Guid(),
                                    Instructions = string.Join("|", recipe.instructions),
                                    Title = recipe.title
                                }
                            );
                            foreach (var ingredients in recipe.ingredients)
                            {
                                ingredientsDB.Add(
                                new Ingredient
                                    {
                                        Id = new Guid(),
                                        Title = ingredients
                                    }
                                );
                            }
                        }
                    }
                }
                Console.WriteLine("importing recipes to DB");
                ctx.Recipes.AddRange(recipesDB);
                ctx.SaveChanges();
                Console.WriteLine("importing ingredients to DB");
                ctx.Ingredients.AddRange(ingredientsDB);
                ctx.SaveChanges();
                Console.WriteLine("import done");
                /*
                var recipes = new List<Recipe>
                {
                    new Recipe {
                        Id = new Guid(),
                        Instructions = "nakrájet, uvařit",
                        Title = "Rajská omáčka"
                    },
                    new Recipe
                    {
                        Id = new Guid(),
                        Instructions = "uvařit",
                        Title = "Bramborová polévka"
                    },
                    new Recipe
                    {
                        Id = new Guid(),
                        Instructions = "namazat",
                        Title = "Palačinky"
                    }
                };

                ctx.Recipes.AddRange(recipes);
                ctx.SaveChanges();*/
            }
            /*
            if (!ctx.Ingredients.Any())
            {
                var ingredients = new List<Ingredient>
                {
                    new Ingredient
                    {
                        Id = new Guid(),
                        Title = "hladká mouka"
                    },
                    new Ingredient
                    {
                        Id = new Guid(),
                        Title = "rajčata"
                    },
                    new Ingredient
                    {
                        Id = new Guid(),
                        Title = "brambory"
                    }
                };

                ctx.Ingredients.AddRange(ingredients);
                ctx.SaveChanges();
            }
            */
            /*
            if (!ctx.RecipeIngredients.Any())
            {
                var joinTbl = new List<RecipeIngredients>
                {
                    new RecipeIngredients {RecipeId="rjskOm", IngredientId="rjsk"},
                    new RecipeIngredients {RecipeId="rjskOm", IngredientId="msl"},
                    new RecipeIngredients {RecipeId="chlbMsl", IngredientId="msl"},
                    new RecipeIngredients {RecipeId="chlbMsl", IngredientId="chlb"},
                };

                ctx.RecipeIngredients.AddRange(joinTbl);
                ctx.SaveChanges();
            }
            */
        }
    }
}
