using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.OleDb;
using WindowsFormsApp1.InformatiCS_LibraryDataSetTableAdapters;


namespace WindowsFormsApp1
{
    //Added multiple exceptions for debug...
    class InsertToAccess
    {
        MediaTableAdapter mda = new MediaTableAdapter();
        LemmaTableAdapter lda = new LemmaTableAdapter();
        Lemma_MediaTableAdapter lmda = new Lemma_MediaTableAdapter();
        CategoryTableAdapter cda = new CategoryTableAdapter();
        Category_LemmaTableAdapter clda = new Category_LemmaTableAdapter();

        public void InsertLemma(string path,List<string> categoryName) //Small change. From array to list
        {
            string fullPath = Path.GetFullPath(path);
            string fileName = Path.GetFileNameWithoutExtension(path);
            string extension = Path.GetExtension(path);
            string content = File.ReadAllText(fullPath);
            string[] splitExtension = extension.Split('.');
            int categoryID = -1, mediaID = -1, lemmaID = -1;
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
                } else{
                    lemmaID = (int)lda.getLemmaIDbyLemmaName(fileName);
                }
                if (!LemmaMedia_Exist(lemmaID, mediaID)){
                    InsertLemmaMedia(lemmaID,mediaID);
                }
                foreach (string i in categoryName) //Small change. From array to list
                {
                    bool insertCategoryComplete = InsertCaterogy(i);
                    if (insertCategoryComplete)
                    {
                        categoryID = GetCategoryID(i);
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
            } catch { return; }
        }
        private void InsertMedia(string extension, String content)
        {
            try
            {
                mda.Insert(extension, content);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return;
            }
        }
        private void InsertLemma(string lemmaName)
        {
            try
            {
                lda.Insert(lemmaName);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return;
            }
        }
        private void InsertLemmaMedia(int lemmaID,int mediaID)
        {
            
            try
            {
                lmda.Insert(lemmaID, mediaID);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return;
            }
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
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                    return false;
                }
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
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return;
            }
        }
        private int GetLastLemmaID()
        {
            int lemmaID = -1;
            try
            {
                lemmaID = (int)lda.getLastLemmaID();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
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
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return -1;
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
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return -1;
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
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
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
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
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
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
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
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
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