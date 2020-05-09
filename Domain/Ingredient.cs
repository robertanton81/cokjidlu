using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        public string IngredientCategory { get; set; }
        public string Title { get; set; }

        public List<RecipeIngredients> RecipesIngredients { get; set; }
    }
}
