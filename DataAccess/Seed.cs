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
            if(!ctx.Recipes.Any())
            {
                var recipes = new List<Recipe>
                {
                    new Recipe {
                        Id = "rjskOm",
                        Instructions = "nakrájet, uvařit",
                        Title = "Rajská omáčka"
                    },
                    new Recipe
                    {
                        Id = "chlbMsl",
                        Instructions = "namazat",
                        Title = "Chléb s máslem"
                    }
                };

                ctx.Recipes.AddRange(recipes);
                ctx.SaveChanges();
            }

            if (!ctx.Ingredients.Any())
            {
                var ingredients = new List<Ingredient>
                {
                    new Ingredient
                    {
                        Id = "chlb",
                        Title = "chléb"
                    },
                    new Ingredient
                    {
                        Id = "rjsk",
                        Title = "rajčata"
                    },
                    new Ingredient
                    {
                        Id = "msl",
                        Title = "máslo"
                    }
                };

                ctx.Ingredients.AddRange(ingredients);
                ctx.SaveChanges();
            }

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
        }
    }
}
