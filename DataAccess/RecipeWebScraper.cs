namespace DataAccess
{
    using System.Collections.Generic;

    class RecipeWebScraper
    {

        public string title { get; set; }
        public string amount;
        public List<string> ingredients = new List<string>();
        public List<string> instructions = new List<string>();
        public string zdroj { get; set; }


        public RecipeWebScraper(string title, string amount, List<string> ingredients, List<string> instructions, string zdroj)
        {
            this.title = title;
            this.amount = amount;
            this.ingredients = ingredients;
            this.instructions = instructions;
            this.zdroj = zdroj;
        }
    }
}
