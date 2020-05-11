using System;
using System.Collections.Generic;

namespace Domain
{
    public class Recipe
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public List<RecipeIngredients> RecipeIngredients { get; set; }

        public string Instructions { get; set; }
    }
}
