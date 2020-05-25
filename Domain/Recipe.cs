namespace Domain
{
    using System;
    using System.Collections.Generic;

    public class Recipe
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Instructions { get; set; }

        public virtual List<RecipeIngredients> RecipeIngredients { get; set; }
    }
}
