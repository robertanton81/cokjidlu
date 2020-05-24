namespace Application.Recipes
{
    using System.Collections.Generic;
    using Domain;
    using System;
    using System.Text.Json.Serialization;

    public class RecipeDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Instructions { get; set; }

        [JsonPropertyName("ingredients")]
        public List<IngredientDto> RecipeIngredients { get; set; }
    }
}
