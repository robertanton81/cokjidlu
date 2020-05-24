namespace Domain
{
    using System;

    public class RecipeIngredients
    {
        public Guid RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public Guid IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }

        /// <summary>
        /// what is the meassure g / kg / ml / spoon
        /// </summary>
        public string Meassure { get; set; }

        public int Qty { get; set; }

        /// <summary>
        /// for how many persons
        /// </summary>
        public int NumberOfServings { get; set; }
    }
}
