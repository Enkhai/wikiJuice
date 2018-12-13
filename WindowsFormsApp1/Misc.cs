using DotNetWikiBot;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Contains miscellaneous methods (Mostly unused)

namespace WindowsFormsApp1
{
    class Misc
    {
        //Save a JObject to a specified file with an optional path
        public static void SaveJObjectToFile(JObject json, string name, string path = null)
        {
            //If path is given
            if (path != null)
            {
                //Try to create directory if not already created
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception) { Console.WriteLine("Directory already exists"); }

                //Concat path with a slash if there is one given
                path = string.Concat(path, "//");

            }

            using (StreamWriter file = File.CreateText($"{path}{name}"))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                json.WriteTo(writer);
            }
        }

        //Use this instead of the API's ReviseInMSWord method!!!!
        //You need to stop the app in order for MSWord to close properly so don't panic
        //Just save what you want and exit
        public static void ReviseInMsWord(Page p)
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
    }
}
