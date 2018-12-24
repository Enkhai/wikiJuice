using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DotNetWikiBot;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Text;
using static WindowsFormsApp1.consoleWriters;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        InsertToAccess insert = new InsertToAccess();
        public Form1()
        {
            InitializeComponent();
            infoTB.Text = "wikiJuice version 0.1" + Environment.NewLine +
                "A source wikipedia" + Environment.NewLine +
                "database creation tool." + Environment.NewLine +
                "Part of the InformatiCS-Library" + Environment.NewLine +
                "application.";
            Console.SetOut(new MultiTextWriter(new ControlWriter(StatusTB), Console.Out));
        }

        private void categoryButton_Click(object sender, EventArgs e)
        {
            try { categoryList.Items.Add(categoryTB.Text); }
            catch { }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                string[] item_arr = new string[2] { searchValueTB.Text, numResultsTB.Text };
                ListViewItem item = new ListViewItem(item_arr);
                searchList.Items.Add(item);
            }
            catch { }
        }

        private void cat_deleteButton_Click(object sender, EventArgs e)
        {
            try { categoryList.Items.RemoveAt(categoryList.SelectedIndex); }
            catch { }

        }

        private void search_deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in searchList.Items)
                    if (item.Selected)
                        searchList.Items.Remove(item);
            }
            catch { }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> searchItems = new Dictionary<string, int> { };
            List<string> categories = new List<string> { };

            try
            {
                foreach (ListViewItem item in searchList.Items) { searchItems.Add(item.SubItems[0].Text, Int32.Parse(item.SubItems[1].Text)); }
                foreach (string item in categoryList.Items) { categories.Add(item); };

                Generator.generate("Enkhai", "Pe4heQui", searchItems, categories);
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            Dir_.SetDirectory(folderBrowserDialog1.SelectedPath);
        }
    }        
}
