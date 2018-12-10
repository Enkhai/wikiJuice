using DotNetWikiBot;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Source database creation class

namespace WindowsFormsApp1
{
    class Generator : Bot //Inherit DotNetWikiBot Bot class
    {

        public static void generate(string user, string pass, Dictionary<string, int> searchItems, List<string> categories)
        {
            //Make Site object, specifying site's URL and your bot account
            Site enWiki = new Site("https://en.wikipedia.org", user, pass);

            GetPageMultipleData(enWiki, searchItems, categories);

            //Dir_.SetDirectory("Database"); //Delete this later. The functions below will
                                      //only be implented inside the bigger function GetPageMultipleData
            //GetPageSearchData(enWiki, searchItem: "Java", searchResults: 10);
            //GetPageSearchData(enWiki, category_switch: true, category: "Computer science");         
        }


        //Stores page data based on desired search items and categories
        public static void GetPageMultipleData(Site wiki, Dictionary<string, int> searchItems, List<string> categories)
        {
            Dir_.SetDirectory("Database");

            foreach (KeyValuePair<string, int> searchItem in searchItems)
            {
                GetPageSearchData(wiki, searchItem: searchItem.Key, searchResults: searchItem.Value);
            }
            foreach (string category in categories)
            {
                GetPageSearchData(wiki, category_switch: true, category: category);
            }
        }

        //Stores page data based on search value and number of results
        public static void GetPageSearchData(Site wiki, string searchItem = "wikipedia", int searchResults = 1, bool category_switch = false, string category = "History of artificial intelligence")
        {
            // Make empty PageList object, representing collection of pages
            PageList pl = new PageList(wiki);
            if (!category_switch)
            {
                //Google search method. This method returns 1 less result
                //Add 1 to your desired amount of search results
                pl.FillFromGoogleSearchResults(searchItem, searchResults + 1);
            }
            else if (category_switch)
            {
                pl.FillFromCategory(category);
            }
            else
            {
                throw new Exception("Type of data retrieval was not defined");
            }

            // Load texts and metadata of all found pages
            pl.LoadWithMetadata();

            //Create cmd process
            Process proc = new Process();
            ProcessStartInfo info = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                UseShellExecute = false,
                WorkingDirectory = Directory.GetCurrentDirectory()
            };

            proc.StartInfo = info;
            proc.Start();

            using (StreamWriter sw = proc.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    foreach (Page p in pl)
                    {
                        bool skip = false;
                        //I need to make a JSON category index from this
                        List<string> categories = p.GetCategories();

                        Console.WriteLine($"\nWorking on page: {p.title}");

                        //Skip if page is like Portal:, File:, Category:, etc
                        if (p.title.Contains(":"))
                        {
                            skip = true;
                        }
                        else
                        {
                            //Try to create wiki page directory if not already crated
                            Dir_.CreateDirectory(p.title);
                        }

                        if (!skip)
                        {
                            Console.WriteLine($"Saving wikitext file of {p.title}");
                            p.SaveToFile($"{p.title}\\{p.title}.wikitext");
                            Console.WriteLine($"Formatting {p.title} file wikitext to plain text");
                            sw.WriteLine($"pandoc -f mediawiki -t plain -o \"{p.title}\\{p.title}\" \"{p.title}\\{p.title}.wikitext\" ");
                            DownloadImages(p);
                        }
                        else
                        {
                            Console.WriteLine("Wikipedia page is irrelevant. " +
                            "Download process and formatting of the text will be skipped.");
                        }
                    }
                }
            }

        }

        //Downloads all images of a page
        public static void DownloadImages(Page page)
        {
            //Try to create directory if not already created
            Dir_.CreateDirectory(page.title);

            //Try to create directory of images if not already created
            Dir_.CreateDirectory(page.title + "//images");

            //Returns a list of image name strings for the article. Iterate through them
            //using a foreach section
            List<string> images = page.GetImages();

            //In order to download anything initialize a WebClient like this
            using (WebClient client = new WebClient())
            {
                foreach (string img in images)
                {
                    DownloadImage(img, page.title);
                }
            }
        }

        //Downloads image <img> from Wikipedia inside the images folder of folder <page_title>
        public static async void DownloadImage(string img, string page_title)
        {
            using (WebClient client = new WebClient())
            {
                //Make sure there are two dashes in directories (special characters)
                Console.WriteLine($"Downloading wikimedia commons HTML source of {img}");
                string src = "";
                try
                {
                    src = await client.DownloadStringTaskAsync("https://commons.wikimedia.org/wiki/" + img);
                    Console.WriteLine("Source downloaded");

                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(src);
                    var img_node = doc.DocumentNode.SelectSingleNode($".//img[@alt='{img}']");
                    string img_src = img_node.GetAttributeValue("src", "Not found");
                    if (img_src.Equals("Not found"))
                    {
                        Console.WriteLine("Image was not found");
                    }
                    else
                    {
                        string img_name = img.Replace("File:", "");
                        await client.DownloadFileTaskAsync(img_src, $"{page_title}//images//{img_name}");
                        Console.WriteLine($"Image {img} downloaded as {img_name} in folder {page_title}//Images");
                    }
                }
                catch
                {
                    Console.WriteLine("Could not download source file");
                }
            }
        } 
    }


}
