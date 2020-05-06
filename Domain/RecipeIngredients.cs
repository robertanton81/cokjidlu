using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class RecipeIngredients
    {
        public string RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public string IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
