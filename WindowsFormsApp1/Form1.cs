using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using DotNetWikiBot;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            test_gen.generate();
            
        }
    }

    public class test_gen: Bot //It is considered necessary for the class to inherit the Bot class
    {

        public static void generate()
        {

            //Parse wikipedia article's text, convert to json and save it to a file called oof
            using (WebClient client = new WebClient())
            {
                //calculate time elapsed
                var watch = System.Diagnostics.Stopwatch.StartNew();

                //API is online called JSONpedia and is used with an HTML query
                //GET for article reference, POST to upload parsed wikitext
                //The following execute(s) a simple GET query
                client.DownloadFile(new Uri("http://jsonpedia.org/annotate/resource/json/en%3AAlbert_Einstein?&procs=Extractors"), @"aaf");
                //client.DownloadFile(new Uri("http://jsonpedia.org/annotate/resource/json/en%3AAlbert_Einstein?&procs=Extractors"), @"bbf");
                //client.DownloadFile(new Uri("http://jsonpedia.org/annotate/resource/json/en%3AAlbert_Einstein?&procs=Extractors"), @"ccf");
                //client.DownloadFile(new Uri("http://jsonpedia.org/annotate/resource/json/en%3AAlbert_Einstein?&procs=Extractors"), @"ddf");
                //client.DownloadFile(new Uri("http://jsonpedia.org/annotate/resource/json/en%3AAlbert_Einstein?&procs=Extractors"), @"eef");
                //client.DownloadFile(new Uri("http://jsonpedia.org/annotate/resource/json/en%3AAlbert_Einstein?&procs=Extractors"), @"fff");

                // the code that you want to measure comes here
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                //JSONpedia is pretty slow...
                //Multiple queries are multiplicative in time
                //How about concatenating text from multiple wikidataitems with POST...?
                Console.WriteLine("Time elapsed: " + (float)elapsedMs/1000 + "seconds");
            }

            // Firstly make Site object, specifying site's URL and your bot account
            Site enWiki = new Site("https://en.wikipedia.org", "Enkhai", "Pe4heQui");
            System.Console.WriteLine("Hello!");
            //Then make Page object, specifying site and page title in constructor
            //Most pages in Wikipedia have aliases that redirect to the original article
            //Calling them by their aliases does not return the original item
            //CALL THEM BY THEIR ACTUAL NAMES!!
            Page p = new Page(enWiki, "Albert Einstein");
            // Load actual page text from live wiki
            p.Load();

            Console.WriteLine("Page id: " + (string)p.pageId);

            //We'll get all the data we need with a similar way
            p.SaveToFile(p.title);

            //Do not use this method yet. Needs some work
            //GetWikidataItem(enWiki, p);

            //Enable if you want to see it in MS Word
            //p.ReviseInMsWord();   doesn't work
            //revise(p);    use this instead

            // Add "Visual arts" category link to "Art" page's text
            //p.AddToCategory("Visual arts");

            
            //DO NOT DO THE FOLLOWING. Don't edit the wiki. We only need the data!
            // Save "Art" article's text back to live wiki with specified comment
            //p.Save("comment: category link added", true);

            // Make empty PageList object, representing collection of pages
            PageList pl = new PageList(enWiki);
            // Fill it with 10 pages, where "computer" is mentioned
            //Google search method. This method returns 9 results instead of 10!!!
            //Add 1 to your desired amount of search results
            pl.FillFromGoogleSearchResults("java", 11); //this option might be better
            //Internal search engine method. Prefer the above method
            //pl.FillFromSearchResults("computer", 10); 
            // Load texts and metadata of all found pages from live wiki
            pl.LoadWithMetadata();
            // Now suppose, that we must correct some typical mistake in all our pages
            //foreach (Page i in pl)
            // In each page we will replace one phrase with another
            //   i.text = i.text.Replace("fusion products", "fission products");

            //Closer inspection... edit: Not much of a use...
            pl.SaveXmlDumpToFile("List.xml");

            //page 8 is Computer program in Wikipedia using FillFromGoogleSearchResults method
            Page eh = pl[5];
            Console.WriteLine("Page name: " + eh.title);
            Console.WriteLine("Page text: \n\n" + eh.text);
            eh.SaveToFile(eh.title);

            //No difference based on what we need to do between the two following
            //List<string> categories = eh.GetAllCategories(); //edit: Don't do this...
            List<string> categories = eh.GetCategories();
            Console.WriteLine("Page categories: ");
            foreach (String cat in categories)
                Console.WriteLine(cat);

            //WikidataItem returns unsupported :/ MUCHO PROBLEMO
            //XElement eh_xml = eh.GetWikidataItem();
            //eh_xml.Save("eh_xml");

            //Console.WriteLine(eh.text); //Very long text boi. Not indicated

            //Let's take a sneak peek in there
            //All files are saved in the project folder inside bin/Debug
            //Look for your files in there. Else declare a different path
            //eh.SaveToFile(eh.title);

            //NOT AN IMAGE!! This was supposed to return the article's main image but Wikipedia's
            //template has changed ever since 2016. Now returns another html page with the image details
            //instead. NOT AN IMAGE!!
            eh.DownloadImage(eh.title + ".html");

            //Returns a list of image name strings for the article. Iterate through them
            //using a foreach section
            List<string> images = eh.GetImages();

            //In order to download anything initialize a WebClient like this
            using (WebClient client = new WebClient())
            {
                int i = 0;
                foreach (String img in images) {
                    //Let's get this bread
                    //Make sure there are two dashes (special characters)
                    Console.WriteLine(img); //debug line
                    //Houston we have a problem... We cannot get an image URL!!!
                    //client.DownloadFile(img, "\\images\\eh(" + i + ")");
                }
            }


            //Returns a list of available language strings for the article. Iterate through them
            //using a foreach section
            List<string> links = eh.GetWikidataLinks();

            using (WebClient client = new WebClient())
            {
                int i = 0;
                foreach (String link in links)
                {
                    //Let's get this bread
                    Console.WriteLine(link);
                }
            }


            //DO NOT DO THE FOLLOWING. Don't edit the wiki. We only need the data!
            // Finally we'll save all changed pages to wiki with 5 seconds interval			
            //pl.SaveSmoothly(5, "comment: mistake autocorrection", true);

            // Now clear our PageList so we could re-use it
            //pl.Clear();
            // Fill it with all articles in "Astronomy" category and it's subcategories
            //pl.FillFromCategoryTree("Astronomy");
            // Download and save all PageList's articles to specified local XML file
            //pl.SaveXmlDumpToFile("Dumps\\ArticlesAboutAstronomy.xml");
            //pl.SaveXmlDumpToFile("C:\\Users\\Ceyx\\source\\repos\\WindowsFormsApp1\\ArticlesAboutAstronomy.xml");

        }

        //Use this instead of the API's ReviseInMSWord method!!!!
        //You need to stop the app in order for MSWord to close properly so don't panic
        //Just save what you want and exit
        public static void revise(Page p)
        {
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            app.Visible = true;
            object mv = System.Reflection.Missing.Value;
            object template = mv;
            object newTemplate = mv;
            object documentType = Microsoft.Office.Interop.Word.WdDocumentType.wdTypeDocument;
            object visible = true;
            Microsoft.Office.Interop.Word.Document doc =
                app.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);
            doc.Words.First.InsertBefore(p.text);
            p.text = null;
            Microsoft.Office.Interop.Word.DocumentEvents_Event docEvents =
                (Microsoft.Office.Interop.Word.DocumentEvents_Event)doc;
            docEvents.Close +=
                new Microsoft.Office.Interop.Word.DocumentEvents_CloseEventHandler(
                    delegate { p.text = doc.Range(ref mv, ref mv).Text; doc.Saved = true; });
            app.Activate();
            while (p.text == null) ;
            p.text = Regex.Replace(p.text, "\r(?!\n)", "\r\n");
            app = null;
            doc = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine(
                Bot.Msg("Text of \"{0}\" page has been revised in Microsoft Word."), p.title);
        }

        //Use this instead of the API GetWikidataItem!!! XML is now deprecated in Wikipedia.
        //Needs to be reworked into something more appropriate (JSON, RDF, N3)
        //Check https://www.wikidata.org/wiki/Special:EntityData/ for more info
        public static XElement GetWikidataItem(Site site, Page page)
        {
            string src = site.GetWebPage(site.indexPath + "?title=" + Bot.UrlEncode(page.title));
            Match m = Regex.Match(src, "href=\"//www\\.wikidata\\.org/wiki/(Q\\d+)");
            if (!m.Success)    // fallback
                m = Regex.Match(src, "\"wgWikibaseItemId\"\\:\"(Q\\d+)\"");
            if (!m.Success)
            {
                Console.WriteLine(string.Format(Bot.Msg(
                    "No Wikidata item is associated with page \"{0}\"."), page.title));
                return null;
            }
            string item = m.Groups[1].Value;
            Console.WriteLine("Item is : " + item);
            string xmlSrc = site.GetWebPage("http://www.wikidata.org/wiki/Special:EntityData/" +
                Bot.UrlEncode(item) + ".xml");    // raises "404: Not found" if not found
            XElement xml = XElement.Parse(xmlSrc);
            Console.WriteLine(string.Format(Bot.Msg(
                "Wikidata item {0} associated with page \"{1}\" was loaded successfully."),
                item, page.title));
            return xml;
        }

    }
}
