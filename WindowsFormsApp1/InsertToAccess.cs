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


        public void InsertLemma(string path,string[] categoryName,string[] imagesPath)
        {
            DirectoryInfo di = new DirectoryInfo("..\\..\\");
            string fileName = Path.GetFileNameWithoutExtension(path);
            string extension = Path.GetExtension(path);

            path = di.ToString() + path;

            Path.GetInvalidPathChars();
            string fullPath = Path.GetFullPath(path);
            String content = File.ReadAllText(path);
            string[] splitExtension = extension.Split('.');
            int categoryID = -1, mediaID = -1, lemmaID = -1;

            string[] splittedImagePath = null;

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

                Console.WriteLine("imagesPath.Length = " + imagesPath.Length);
                for (int i = 0; i < imagesPath.Length; i++)
                {
                    splittedImagePath = imagesPath[i].Split('.');
                    Console.WriteLine("extention = " + splittedImagePath[1] + ", content = " + splittedImagePath[0]);

                    if (!Media_Exist(splittedImagePath[0]))
                    {
                        InsertMedia(splittedImagePath[1], splittedImagePath[0]);
                        mediaID = GetLastMediaID();
                        if (!LemmaMedia_Exist(lemmaID, mediaID))
                        {
                            InsertLemmaMedia(lemmaID, mediaID);
                        }
                    }
                    else
                    {
                        mediaID = (int)mda.getMediaIDbyContent(splittedImagePath[0]);
                        if (!LemmaMedia_Exist(lemmaID, mediaID))
                        {
                            InsertLemmaMedia(lemmaID, mediaID);
                        }
                    }
                }

                for (int i = 0; i < categoryName.Length;i++)
                {
                    bool insertCategoryComplete = InsertCaterogy(categoryName[i]);
                    if (insertCategoryComplete)
                    {
                        categoryID = GetCategoryID(categoryName[i]);
                    }
                    else
                    {
                        categoryID = GetLastCategoryID();
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