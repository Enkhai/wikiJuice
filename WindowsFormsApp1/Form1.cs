﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public System.Windows.Forms.Timer action_timer = new System.Windows.Forms.Timer() { Interval = 3000, Enabled = true };
        KeyValuePair<int, int> tick = new KeyValuePair<int, int>(0, 0);

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
            //test.FooAsync();
            //Disable the buttons
            generateButton.Enabled = false;
            saveButton.Enabled = false;
            //Initialize the tick
            tick = new KeyValuePair<int, int>(0, 0);

            //Clear the Status textbox
            StatusTB.Clear();
            //And start anew
            StatusTB.AppendText($"Logged in as {usernameTB.Text}" + Environment.NewLine);

            //Preparations for the generate function call
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

            //Start the timer and print the status every 3 seconds
            action_timer.Tick += new EventHandler(printStatus);
            action_timer.Disposed += new EventHandler(completeGenerate);
            action_timer.Start();

            StatusTB.AppendText(Environment.NewLine + "Working..." + Environment.NewLine);

            //Start the generator
            Task task = Task.Run(() =>
            {
                Generator.generate(usernameTB.Text, passwordTB.Text, searchItems, categories);

                this.Invoke(new Action(() => action_timer.Dispose()));
            });
        }

        private void completeGenerate(object sender, EventArgs e)
        {
            //Print and save the report
            foreach (var value in Generator.getReport().Values)
            {
                StatusTB.AppendText(value);
            }
            Generator.saveReport();

            //Print the outcome
            StatusTB.AppendText(Environment.NewLine + Environment.NewLine +
                "Total: Downloaded/failed images: " +
                Generator.getImageSuccesses() + "/" + Generator.getImageFailures());
            StatusTB.AppendText(Environment.NewLine + "Done");

            //Re-enable the buttons
            generateButton.Enabled = true;
            saveButton.Enabled = true;
        }

        private void printStatus(object sender, EventArgs e)
        {
            int succ_gen = Generator.getSuccessfulGenerations();
            int succ_img = Generator.getImageSuccesses();
            int fail_gen = Generator.getIgnoredGenerations();
            int fail_img = Generator.getImageFailures();
            KeyValuePair<int, int> temp = new KeyValuePair<int, int>(tick.Key + 1, succ_gen + succ_img + fail_gen + fail_img);

            StatusTB.AppendText(Environment.NewLine + $"Tick {temp.Value}:" + Environment.NewLine + "Successful/ignored generations: " +
                Generator.getSuccessfulGenerations() + "/" + Generator.getIgnoredGenerations() + Environment.NewLine +
                "Downloaded/failed images: " + Generator.getImageSuccesses() + "/" + Generator.getImageFailures());

            tick = temp;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            Dir_.SetDirectory(folderBrowserDialog1.SelectedPath);
        }

        private void fileCategoriesButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                try { categoryList.Items.Add(line); }
                catch { }
            }
        }
    }
}
