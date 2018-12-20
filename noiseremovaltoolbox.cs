using System;
using System.Text;
using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.IO;

namespace WindowsFormsApp1
{
    class NoiseRemovalToolbox
    {
        void convert_file(String fname)
        {
            if (!File.Exists(fname))
            {
                System.Console.WriteLine("Invalid Path!");
            }

            //This fname,is a path to the file i want to convert and remove noise
            String line;
            string foldername = System.IO.Path.GetDirectoryName(fname);
            string filename = System.IO.Path.GetFileName(fname);
            //MessageBox.Show("FOLDER NAME" + foldername);
            //MessageBox.Show("FILE NAME" + filename);

            System.IO.StreamReader sr = new System.IO.StreamReader(fname);


            System.IO.StreamWriter newfile = new System.IO.StreamWriter(fname + "(new)", true, Encoding.UTF8, 4);


            while ((line = sr.ReadLine()) != null)
            {


                //System.Console.WriteLine("BEFORE==>"+line);
                //String newline1 = check_and_return_line(line);
                String newline2 = check_and_return_line(line);
                //System.Console.WriteLine("AFTER==>" + newline2);
                if (!newline2.Contains("See also") & !newline2.Contains("References"))
                {

                    if (newline2.Contains("---+") || newline2.Contains("======="))
                    {
                        //do nothing when inspecting a start of table

                    }
                    else if (newline2.Contains("|"))
                    {
                        //do nothing when inspecting a line of table

                    }
                    else
                    {
                        //write the line to the new file
                        newfile.WriteLine(newline2);

                    }



                }
                else
                {
                    //System.Console.WriteLine(System.DateTime.Now);
                    break;
                }


            }
            sr.Close();
            newfile.Close();


        }
        private String check_and_return_line(String beforeline)
        {
            int start = beforeline.IndexOf("[");
            int end = beforeline.IndexOf("]");
            string newline = beforeline;
            //System.Console.WriteLine("START" + start + " END "+end);
            int number_of_characters_to_cut = end - start + 1;
            StringBuilder b = new StringBuilder(beforeline);
            if (start != -1 && end != -1)
            {
                if (start < end)
                {
                    b.Remove(start, number_of_characters_to_cut);
                    newline = check_and_return_line(b.ToString());
                }
            }

            return newline;
        }
    }
}
