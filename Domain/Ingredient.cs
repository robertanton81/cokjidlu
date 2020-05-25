namespace Domain
{
    using System;
    using System.Collections.Generic;

    public class Ingredient
    {
        public Guid Id { get; set; }

        public string IngredientCategory { get; set; }

        public string Title { get; set; }

        public virtual List<RecipeIngredients> RecipesIngredients { get; set; }
    }
}
