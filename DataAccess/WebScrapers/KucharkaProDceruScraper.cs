using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DataAccess.WebScrapers
{
    class KucharkaProDceruScraper
    {
        private static string url = "https://www.kucharkaprodceru.cz/";
        private List<String> getAllUrls()
        {
            List<String> urls = new List<string>();
            urls.Add("https://www.kucharkaprodceru.cz/chia-seminka/");
            urls.Add("https://www.kucharkaprodceru.cz/jatrova-pastika/"); 
            urls.Add("https://www.kucharkaprodceru.cz/ovesne-vlocky-recept/");
            urls.Add("https://www.kucharkaprodceru.cz/belese-recept/");
            urls.Add("https://www.kucharkaprodceru.cz/recepty-z-kureciho-masa/");
            urls.Add("https://www.kucharkaprodceru.cz/samosy/");
            urls.Add("https://www.kucharkaprodceru.cz/kvetakovy-bulgur/");
            urls.Add("https://www.kucharkaprodceru.cz/noky-s-pecenymi-rajcaty/");
            urls.Add("https://www.kucharkaprodceru.cz/vanocni-rybi-polevka-pro-zacatecniky/");
            urls.Add("https://www.kucharkaprodceru.cz/grilovana-kureci-stehna/");
            urls.Add("https://www.kucharkaprodceru.cz/vareni-tepelna-uprava/");
            urls.Add("https://www.kucharkaprodceru.cz/kachni-prsa/");
            return urls;
        }

        public List<List<RecipeWebScraper>> getRecipes()
        {
            KucharkaProDceruScraperOnePage ksOP = new KucharkaProDceruScraperOnePage();
            List<List<RecipeWebScraper>> recipes = new List<List<RecipeWebScraper>>();
            foreach (var url in getAllUrls())
            {
                recipes.Add(ksOP.getRecipe(url));
                
            }
            return recipes;
        }
    }
}