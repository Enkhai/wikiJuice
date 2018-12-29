using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.OleDb;
using WindowsFormsApp1.InformatiCS_LibraryDataSetTableAdapters;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class InsertToAccess
    {
        MediaTableAdapter mda = new MediaTableAdapter();
        LemmaTableAdapter lda = new LemmaTableAdapter();
        Lemma_MediaTableAdapter lmda = new Lemma_MediaTableAdapter();
        CategoryTableAdapter cda = new CategoryTableAdapter();
        Category_LemmaTableAdapter clda = new Category_LemmaTableAdapter();

        /// <summary>
        /// as path give the relative path from ~\WindowsFormsApp1 and under,
        /// <para>¬Example: "\\Database\\file1.txt".</para>
        /// <para>as categoryName give the List of string, with names of the categories that Lemma belongs.</para>
        /// <para>as imagesPath give the relative path of the images Directory </para>
        /// <para>¬Example: "\\Database\\images\\".</para>
        /// </summary>
        public void InsertLemma(string path,List<string> categoryName,string imagesDirectory)
        {
            String content = null;
            string[] files = null;
            string[] finalImagePath = null;
            int pathPos = 100;
            bool findDirectory = false;
            int imagePathCounter = 0;

            string currentDir = Directory.GetCurrentDirectory();
            string fileName = Path.GetFileNameWithoutExtension(path);
            string extension = null;
            if(Path.GetExtension(path) == null)
            {
                extension = "txt";
            }
            else
            {
                extension = Path.GetExtension(path);
            }

            path = currentDir + path;

            string fullPath = Path.GetFullPath(path);

            content = File.ReadAllText(fullPath);
            string[] splitExtension = extension.Split('.');
            int categoryID = -1, mediaID = -1, lemmaID = -1;

            string[] splittedImagePath = null;
            string[] splittedImagePathContent = null;

            try
            {
                if (!Media_Exist(content))
                {
                    InsertMedia(splitExtension[1], content);
                    mediaID = GetLastMediaID();
                } else {
                    mediaID = (int)mda.getMediaIDbyContent(content);
                }
                if (!Lemma_Exist(fileName)){
                    InsertLemma(fileName);
                    lemmaID = GetLastLemmaID();
                }
                else
                {
                    lemmaID = (int)lda.getLemmaIDbyLemmaName(fileName);
                }
                if (!LemmaMedia_Exist(lemmaID, mediaID)){
                    InsertLemmaMedia(lemmaID,mediaID);
                }

                files = Directory.GetFiles(currentDir + imagesDirectory);

                finalImagePath = new string[files.Length];

                foreach (string file in files)
                {
                    finalImagePath[imagePathCounter] = "";
                    splittedImagePath = file.Split('.');
                    splittedImagePathContent = splittedImagePath[0].Split('\\');

                    for (int i = 0; i < splittedImagePathContent.Length; i++)
                    {
                        if(splittedImagePathContent[i] == "WindowsFormsApp1")
                        {
                            pathPos = i;
                            findDirectory = true;
                        }
                        if(pathPos < i && findDirectory)
                        {
                            finalImagePath[imagePathCounter] += "\\" + splittedImagePathContent[i];
                        }
                    }
                    Console.WriteLine("finalImagePath = " + finalImagePath[imagePathCounter]);
                    if (!Media_Exist(finalImagePath[imagePathCounter]))
                    {
                        InsertMedia(splittedImagePath[1], finalImagePath[imagePathCounter]);
                        mediaID = GetLastMediaID();
                        if (!LemmaMedia_Exist(lemmaID, mediaID))
                        {
                            InsertLemmaMedia(lemmaID, mediaID);
                        }
                    }
                    else
                    {
                        mediaID = (int)mda.getMediaIDbyContent(finalImagePath[imagePathCounter]);
                        if (!LemmaMedia_Exist(lemmaID, mediaID))
                        {
                            InsertLemmaMedia(lemmaID, mediaID);
                        }
                    }
                    imagePathCounter++;
                }

                foreach(string category in categoryName)
                {
                    bool insertCategoryComplete = InsertCaterogy(category);
                    if (insertCategoryComplete)
                    {
                        categoryID = GetLastCategoryID(); 
                    }
                    else
                    {
                        categoryID = GetCategoryID(category);
                    }
                    if (categoryID > -1 && !CategoryLemma_Exist(categoryID, lemmaID))
                    {
                        InsertCategoryLemma(categoryID);
                    }
                }
            } catch(Exception ex)
            {
                Console.WriteLine("Error!!!!! \n"+ex.Message);
            }
        }

        private void InsertMedia(string extension, String content)
        {
            try
            {
                mda.Insert(extension, content);
            }
            catch{}
        }
        private void InsertLemma(string lemmaName)
        {
            try
            {
                lda.Insert(lemmaName);
            }
            catch{}
        }
        private void InsertLemmaMedia(int lemmaID,int mediaID)
        {
            
            try
            {
                lmda.Insert(lemmaID, mediaID);
            }
            catch { }
        }
        private bool InsertCaterogy(string categoryName)
        {
            if (!Category_Exist(categoryName))
            {
                try
                {
                    cda.Insert(categoryName);
                    return true;
                }
                catch { }
            }
            return false;
        }
        private void InsertCategoryLemma(int categoryID)
        {
            int lemmaID = GetLastLemmaID();
            
            try
            {
                //clda.InsertCategoryLemma(categoryID, lemmaID);
                clda.Insert(categoryID, lemmaID);
            }
            catch { }
        }
        private int GetLastLemmaID()
        {
            int lemmaID = -1;
            try
            {
                lemmaID = (int)lda.getLastLemmaID();
            }
            catch
            { 
                lemmaID = -1;
            }

            return lemmaID;
        }
        private int GetLastMediaID()
        {
            int mediaID = -1;
            try
            {
                mediaID = (int)mda.getLastMediaID();
            }
            catch
            { 
                mediaID = -1;
            }

            return mediaID;
        }
        private int GetLastCategoryID()
        {
            int categoryID = -1;
            try
            {
                categoryID = (int)cda.getLastCategoryID();
            }
            catch
            {
                categoryID = -1;
            }

            return categoryID;
        }
        private int GetCategoryID(string categoryName)
        {
            int categoryID = -1;
            try
            {
                categoryID = (int)cda.getCategoryIDbyCategoryName(categoryName);
            }
            catch
            {
                categoryID = -1;
            }
            return categoryID;
        }
        private bool Category_Exist(string categoryName)
        {
            bool exist = false;
            int count = -1;
            try
            {
                count = (int)cda.CategoryExist(categoryName);
                if(count == 1)
                    exist = true;
            }
            catch
            {
                exist = false;
            }
            return exist;
        }
        private bool Lemma_Exist(string name)
        {
            bool exist = false;
            int count = -1;
            try
            {
                count = (int)lda.LemmaExist(name);
                if (count == 1)
                    exist = true;
            }
            catch
            {
                exist = false;
            }
            return exist;
        }
        private bool Media_Exist(string content)
        {
            bool exist = false;
            int count = -1;
            try
            {
                count = (int)mda.MediaExist(content);
                if (count == 1)
                    exist = true;
            }
            catch
            {
                exist = false;
            }
            return exist;
        }
        private bool LemmaMedia_Exist(int lemmaID,int mediaID)
        {
            bool exist = false;
            int count = -1;
            count = (int)lmda.LemmaMediaExist(lemmaID, mediaID);
            if(count == 1)
            {
                exist = true;
            }
            return exist;
        }
        private bool CategoryLemma_Exist(int categoryID,int lemmaID)
        {
            bool exist = false;
            int count = -1;
            count = (int)clda.CategoryLemmaExist(categoryID, lemmaID);
            if(count == 1)
            {
                exist = true;
            }
            return exist;
        }
    }
}