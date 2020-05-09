using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class RecipeIngredients
    {
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public Guid IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
