using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetWikiBot;

namespace WindowsFormsApp1
{
    class test
    {
        public static async void FooAsync()
        {
            //InsertToAccess insert = new InsertToAccess();
            //List<string> categories = new List<string>
            //{
            //    "Artificial intelligence"
            //};
            //insert.InsertLemma(@"C:\Users\Ceyx\source\repos\WindowsFormsApp1\WindowsFormsApp1\bin\Debug\Database\Artificial intelligence\Artificial intelligence(new)", categories);

            Site enWiki = new Site("https://en.wikipedia.org", "*****", "*****");

            List<string> categories = new List<string> {
                "Artificial intelligence", "Linear algebra", "Statistics",
                "Microprocessors", "IEEE 802.11"
            };

            Generator.GetPageMultipleData(enWiki, new Dictionary<string, int> { }, categories);
            Console.WriteLine("Counting the clouds...");

            //PageList pl = new PageList(enWiki);
            //pl.FillFromGoogleSearchResults("Art", 11);
            //pl.LoadWithMetadata();
            //await Generator.DownloadImagesAsync(pl[1]);
            //Console.WriteLine("Waiting for the train...");
            //Generator.GetPageSearchData(enWiki, "Eros", 11);
            //Console.WriteLine("Waiting for the leaves to fall...");
        }
    }
}
