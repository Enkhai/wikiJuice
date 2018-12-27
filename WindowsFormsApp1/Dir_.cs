using System;
using System.IO;

//Directory control class

namespace WindowsFormsApp1
{
    class Dir_
    {
        //Sets the current directory. If it does not exists, it creates it
        public static void SetDirectory(string path)
        {
            //First set the directory to Database (the folder which we'll be working on)
            try
            {
                Directory.SetCurrentDirectory(path);
            }
            catch
            {
                Console.WriteLine($"Directory {path} does not exist. Creating directory");
                Directory.CreateDirectory(path);
                Directory.SetCurrentDirectory(path);
            }
        }

        //Creates a directory
        public static void CreateDirectory(string path)
        {
            //Try to create directory if not already created
            try
            {
                Directory.CreateDirectory(path);
            }
            catch { Console.WriteLine($"Directory {path} exists"); }
        }

    }
}
