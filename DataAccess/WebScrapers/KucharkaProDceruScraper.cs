namespace DataAccess.WebScrapers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Text.RegularExpressions;

    class KucharkaProDceruScraper
    {
        private static string url = "https://www.kucharkaprodceru.cz/recepty/";
        private List<String> getAllUrls()
        {
            List<String> urls = new List<string>();

            int hrefInLiIndexStart;
            int hrefInLiIndexEnd;
            WebClient client = new WebClient();
            string html = client.DownloadString(url);
            html = Regex.Replace(html, @"\s+", " ");

            List<String> divSplitList = new List<string>();
            divSplitList = Regex.Split(html, "vc_row wpb_row vc_row-fluid").ToList();
            if (divSplitList.Count() > 1)
            {
                foreach (var div in divSplitList)
                {
                    if (div.IndexOf("<ul> <li>") > 1)
                    {

                        List <String> liSplitList = new List<string>();
                        liSplitList = Regex.Split(div, "<li>").ToList();
                        foreach (var li in liSplitList)
                        {
                            hrefInLiIndexStart = li.IndexOf("href=\"");
                            if (hrefInLiIndexStart > 1)
                            {
                                hrefInLiIndexEnd = li.IndexOf(">", hrefInLiIndexStart);
                                urls.Add(li.Substring(hrefInLiIndexStart + 6 ,hrefInLiIndexEnd - hrefInLiIndexStart - 7));
                            }
                        }
                    }
                }
            }
            /*
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
            urls.Add("https://www.kucharkaprodceru.cz/kachni-prsa/");*/
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