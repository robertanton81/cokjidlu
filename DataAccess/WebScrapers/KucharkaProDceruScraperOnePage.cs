using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace DataAccess.WebScrapers
{
    class KucharkaProDceruScraperOnePage
    {
        string recipesSplitString = "<div id=\"zlrecipe-innerdiv\">";
        string ingredientsSplitString = "itemprop=\"ingredients\"";
        string instructionsSplitString = "itemprop=\"recipeInstructions\">";
        string titleSplitString = "<div id=\"zlrecipe-title\"";
        string amountSplitString = "<span itemprop=\"recipeYield\">";

        public List<RecipeWebScraper> getRecipe(string url)
        {
            List<String> recipesSplitList = new List<string>();

            List<RecipeWebScraper> RecipesList = new List<RecipeWebScraper>();

            WebClient client = new WebClient();
            string html = client.DownloadString(url);
            html = Regex.Replace(html, @"\s+", " ");
            recipesSplitList = Regex.Split(html, recipesSplitString).ToList();
            if (recipesSplitList.Count > 1)
            {
                recipesSplitList.RemoveAt(0);
                int recipesSplitListLength = recipesSplitList.Count();
                recipesSplitList[recipesSplitListLength - 1] = recipesSplitList[recipesSplitListLength - 1].Substring(0, recipesSplitList[recipesSplitListLength - 1].IndexOf("copyrightHolder"));
                string title;
                string titleHelper;
                int indexOfTitle;
                string lastListString;
                string amount;
                string amountHelper;
                int amountStart;
                foreach (var recipe in recipesSplitList)
                {
                    List<String> instructionsSplitList = new List<string>();
                    List<String> instructionsReturn = new List<string>();

                    List<String> ingredientsSplitList = new List<string>();
                    List<String> ingredientsReturn = new List<string>();

                    indexOfTitle = recipe.IndexOf(titleSplitString);
                    titleHelper = recipe.Substring(indexOfTitle, recipe.IndexOf("</div>", indexOfTitle) - indexOfTitle);
                    title = titleHelper.Substring(titleHelper.IndexOf(">") + 1, titleHelper.Length - titleHelper.IndexOf(">") - 1);

                    amountStart = recipe.IndexOf(amountSplitString);
                    if (amountStart == -1)
                    {
                        amount = string.Empty;
                    }
                    else
                    {
                        amountHelper = recipe.Substring(recipe.IndexOf(amountSplitString) + amountSplitString.Length, recipe.Length - recipe.IndexOf(amountSplitString) - amountSplitString.Length);
                        amount = amountHelper.Substring(0, amountHelper.IndexOf("</span>"));
                    }


                    instructionsSplitList = Regex.Split(recipe, instructionsSplitString).ToList();
                    instructionsSplitList.RemoveAt(0);
                    lastListString = instructionsSplitList[instructionsSplitList.Count() - 1];
                    lastListString = lastListString.Substring(0, lastListString.IndexOf("</ol>"));
                    instructionsSplitList[instructionsSplitList.Count() - 1] = lastListString;
                    foreach (var item in instructionsSplitList)
                    {
                        instructionsReturn.Add(item.Substring(0, item.IndexOf("</li>") - 1));
                    }



                    ingredientsSplitList = Regex.Split(recipe, ingredientsSplitString).ToList();
                    ingredientsSplitList.RemoveAt(0);
                    lastListString = ingredientsSplitList[ingredientsSplitList.Count() - 1];
                    lastListString = lastListString.Substring(0, lastListString.IndexOf("</ul>"));
                    ingredientsSplitList[ingredientsSplitList.Count() - 1] = lastListString;
                    foreach (var item in ingredientsSplitList)
                    {
                        ingredientsReturn.Add(item.Substring(1, item.IndexOf("</li>") - 1));
                    }


                    RecipesList.Add(new RecipeWebScraper(title, amount, ingredientsReturn, instructionsReturn, url));
                }
            }
            return RecipesList;
        }
    }
}