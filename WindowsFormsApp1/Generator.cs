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
using static WindowsFormsApp1.consoleWriters;

//Source database creation class

namespace WindowsFormsApp1
{
    class Generator : Bot //Inherit DotNetWikiBot Bot class
    {
        private static int succ_generations = 0;
        private static int fail_generations = 0;
        private static int succ_images = 0;
        private static int fail_images = 0;
        private static Dictionary<int, string> reportDict = new Dictionary<int, string> { };

        public static int getSuccessfulGenerations() { return succ_generations; }

        public static int getIgnoredGenerations() { return fail_generations; }
        
        public static int getImageSuccesses() { return succ_images; }

        public static int getImageFailures() { return fail_images; }

        public static Dictionary<int, string> getReport() { return reportDict; }

        public static void reset() { succ_generations = 0; fail_generations = 0; reportDict.Clear(); }

        private static void makeReport(string user)
        {            
            reportDict.Add(reportDict.Count, Environment.NewLine + "**wikiJuice report**" + Environment.NewLine +
                $"Logged in as {user}" + Environment.NewLine +
                "Date: " + DateTime.Now.ToString() + Environment.NewLine +
                "Author: " + Environment.UserName + Environment.NewLine +
                Environment.NewLine +
                "------------------------------------------------------------------" +
                Environment.NewLine);
        }

        public static void saveReport(string path = null)
        {
            if (path == null)
            {
                path = Directory.GetCurrentDirectory();
            }
            File.WriteAllLines("Report.txt", reportDict.Select(pair => string.Format("{0}", pair.Value)));

            Console.WriteLine("Report has been saved");
        }

        //Generates a database from Wikipedia based on Wikipedia user, password, a dictionairy of 
        //search items and a list of categories
        public static void generate(string user, string pass, Dictionary<string, int> searchItems, List<string> categories)
        {
            reset();
            Console.WriteLine("Generator has been reset");

            makeReport(user);
            try
            {
                Site enWiki = new Site("https://en.wikipedia.org", user, pass);

                Dir_.SetDirectory("Database");

                GetPageMultipleData(enWiki, searchItems, categories);
            }
            catch { Console.WriteLine("User login failed"); }

            reportDict.Add(reportDict.Count, Environment.NewLine + Environment.NewLine +
                "------------------------------------------------------------------" +
                Environment.NewLine + Environment.NewLine +
                $"Number of successfully generated pages: {succ_generations}" +
                Environment.NewLine + $"Number of ignored pages: {fail_generations}");
        }

        //Stores page data based on desired search items and categories
        public static void GetPageMultipleData(Site wiki, Dictionary<string, int> searchItems, List<string> categories)
        {
            reportDict.Add(reportDict.Count, Environment.NewLine + "**Getting report for search items: **" + Environment.NewLine);

            foreach (KeyValuePair<string, int> searchItem in searchItems)
            {
                reportDict.Add(reportDict.Count, Environment.NewLine + $">{searchItem.Key} ({searchItem.Value}):" + Environment.NewLine);
                try { GetPageSearchData(wiki, searchItem: searchItem.Key, searchResults: searchItem.Value); }
                catch { reportDict.Add(reportDict.Count, "Could not yield search results");  }
            }

            reportDict.Add(reportDict.Count, Environment.NewLine + "**Getting report for categories: **" + Environment.NewLine);

            foreach (string category in categories)
            {
                reportDict.Add(reportDict.Count, Environment.NewLine + $">{category}:" + Environment.NewLine + Environment.NewLine);
                try { GetPageSearchData(wiki, category_switch: true, category: category); }
                catch { reportDict.Add(reportDict.Count, "Category not found"); }
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
                WorkingDirectory = Directory.GetCurrentDirectory(),
                CreateNoWindow = true
            };

            proc.StartInfo = info;
            proc.Exited += new EventHandler(ProcExitHandler);
            proc.Start();

            using (StreamWriter sw = proc.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    foreach (Page p in pl)
                    {
                        var t = Task.Run(() => {
                            //Formats page titles containing slashes for directory use eg. TCP/IP->TCP//IP
                            p.title = p.title.Replace("/", "-");
                            Console.WriteLine($"\nWorking on page {p.title}");

                            //I need to make a JSON category index from this
                            List<string> categories = p.GetCategories();

                            //Skip if page is like Portal:, File:, Category:, etc
                            if (p.title.Contains(":"))
                            {
                                Console.WriteLine("Page has been ignored");
                                reportDict.Add(reportDict.Count, $"*{p.title}: " + "ignored" + Environment.NewLine);
                                fail_generations++;
                            }
                            else
                            {
                                //Try to create wiki page directory if not already created
                                Dir_.CreateDirectory(p.title);

                                try
                                {
                                    p.SaveToFile($"{p.title}\\{p.title}.wikitext");
                                }
                                catch { }
                                sw.WriteLine($"pandoc -f mediawiki -t plain -o \"{p.title}\\{p.title}\" \"{p.title}\\{p.title}.wikitext\" ");
                                Console.WriteLine($"Text of page {p.title} has been formatted");

                                reportDict.Add(reportDict.Count, $"*{p.title}: " + "accepted" + Environment.NewLine);
                                succ_generations++;

                                DownloadImages(p);
                            }
                        });
                        t.Wait();
                    }
                }
            }

            void ProcExitHandler(object sender, EventArgs e)
            {
                proc.Dispose();
            }

        }

        //Downloads all images of a page
        public static void DownloadImages(Page page)
        {
            //Try to create directory if not already created
            Dir_.CreateDirectory(page.title);

            //Try to create directory of images if not already created
            Dir_.CreateDirectory(page.title + "//images");
                        
            List<string> images = page.GetImages();
            
            foreach (string img in images)
            {
                DownloadImage(img, page.title);
            }
        }

        //Downloads image <img> from Wikipedia inside the images folder of folder <page_title>
        public static async void DownloadImage(string img, string page_title)
        {
            using (WebClient client = new WebClient())
            {
                bool success = false;

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
                        Console.WriteLine($"Image {img} downloaded as {img_name} in folder {page_title}/Images");
                        success = true;
                    }
                }
                catch
                {
                    Console.WriteLine("Could not download source file");
                }

                if (success) { succ_images++; } else { fail_images++; }
            }
        }

    }

}
