using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public System.Windows.Forms.Timer action_timer = new System.Windows.Forms.Timer() { Interval = 3000, Enabled = true };
        KeyValuePair<int, int> tick = new KeyValuePair<int, int> (0, 0);
        int inactivity = 0;

        public Form1()
        {
            InitializeComponent();
            infoTB.Text = "wikiJuice version 0.1" + Environment.NewLine +
                "A source wikipedia" + Environment.NewLine +
                "database creation tool." + Environment.NewLine +
                "Part of the InformatiCS-Library" + Environment.NewLine +
                "application.";
            
            //Console.SetOut(new MultiTextWriter(new ControlWriter(StatusTB), Console.Out));
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
            generateButton.Enabled = false;
            inactivity = 0;
            tick = new KeyValuePair<int, int>(0, 0);

            StatusTB.Clear();
            StatusTB.AppendText($"Logged in as {usernameTB.Text}" + Environment.NewLine);

            Dictionary<string, int> searchItems = new Dictionary<string, int> { };
            List<string> categories = new List<string> { };

            StatusTB.AppendText(Environment.NewLine + "*Search items:" + Environment.NewLine);
            foreach (ListViewItem item in searchList.Items)
            {
                StatusTB.AppendText($">{item.SubItems[0].Text}({item.SubItems[1].Text})" + Environment.NewLine);
                searchItems.Add(item.SubItems[0].Text, Int32.Parse(item.SubItems[1].Text));
            }

            StatusTB.AppendText(Environment.NewLine + "*Categories:" + Environment.NewLine);
            foreach (string item in categoryList.Items)
            {
                StatusTB.AppendText(">" + item + Environment.NewLine);
                categories.Add(item);
            };

            try
            {                
                action_timer.Tick += new EventHandler(printStatus);
                action_timer.Start();

                StatusTB.AppendText(Environment.NewLine + "Working..." + Environment.NewLine);

                Generator.generate(usernameTB.Text, passwordTB.Text, searchItems, categories);
            }
            catch { }
        }

        private void printStatus(object sender, EventArgs e)
        {
            int succ_gen = Generator.getSuccessfulGenerations();
            int succ_img = Generator.getImageSuccesses();
            int fail_gen = Generator.getIgnoredGenerations();
            int fail_img = Generator.getImageFailures();
            KeyValuePair<int, int> temp = new KeyValuePair<int, int>( tick.Key+1 , succ_gen + succ_img + fail_gen + fail_img);
            if (temp.Value == tick.Value && inactivity > 3* (categoryList.Items.Count + searchList.Items.Count))
            {
                action_timer.Stop();
                foreach (var value in Generator.getReport().Values)
                {
                    StatusTB.AppendText(value);
                }
                Generator.saveReport();
                StatusTB.AppendText(Environment.NewLine + Environment.NewLine + 
                    "Total: Downloaded/failed images: " + 
                    Generator.getImageSuccesses() + "/" + Generator.getImageFailures());
                StatusTB.AppendText(Environment.NewLine + "Done");
                generateButton.Enabled = true;

            }
            else if (temp.Value == tick.Value) { inactivity++; }
            else {
                StatusTB.AppendText(Environment.NewLine + $"Tick {temp.Value}:" + Environment.NewLine +  "Successful/ignored generations: " +
                    Generator.getSuccessfulGenerations() + "/" + Generator.getIgnoredGenerations() + Environment.NewLine +
                    "Downloaded/failed images: " + Generator.getImageSuccesses() + "/" + Generator.getImageFailures());
            }
            tick = temp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            Dir_.SetDirectory(folderBrowserDialog1.SelectedPath);
        }

    }        
}
