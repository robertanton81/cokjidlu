/*using DataAccess.WebScrapers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    class WebScraper
    {
        public bool KucharkaProDceru { get; set; }
        public List<List<List<RecipeWebScraper>>> getRecipes()
        {
            List<List<List<RecipeWebScraper>>> recipes = new List<List<List<RecipeWebScraper>>>(); 
            if (KucharkaProDceru)
            {
                KucharkaProDceruScraper ks = new KucharkaProDceruScraper();
                recipes.Add(ks.getRecipes());
            }

            return recipes;
        }
    }
}
*/