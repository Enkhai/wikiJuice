using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net;
using Lucene.Net.Store;
using Lucene.Net.Index;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Util;
using LVersion = Lucene.Net.Util.Version;
using Lucene.Net.Documents;
using WindowsFormsApp1.InformatiCS_LibraryDataSetTableAdapters;
using System.Data.Common;
using System.Data;
using System.Windows.Forms;
using static WindowsFormsApp1.InformatiCS_LibraryDataSet;
using System.Data.OleDb;

public class Indexer : IDisposable
{
    public String IndexDirectory = "Index";
    public String DataDirectory = "Data";
    public String CategoryIndexDirectory = "IndexCategory";

    private IndexWriter writer;
    private IndexWriter writerCategory;


    private Lemma_MediaTableAdapter lmta = new Lemma_MediaTableAdapter();
    private Category_LemmaTableAdapter clta = new Category_LemmaTableAdapter();
    
    public Indexer()
    {
        Setup();
        SetupCategory();
    }

    public void SetupCategory()
    {
        Directory dir = FSDirectory.Open(CategoryIndexDirectory);
        try
        {
            writerCategory = new IndexWriter(dir, new StandardAnalyzer(LVersion.LUCENE_30), IndexWriter.MaxFieldLength.UNLIMITED);
        }
        catch (Lucene.Net.Store.LockObtainFailedException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void Setup()
    {
        Directory dir = FSDirectory.Open(IndexDirectory);
        try
        {
            writer = new IndexWriter(dir, new StandardAnalyzer(LVersion.LUCENE_30), IndexWriter.MaxFieldLength.UNLIMITED);
        }catch (Lucene.Net.Store.LockObtainFailedException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void Dispose()
    {
        writer.Dispose();
    }

    public void DisposeCategory()
    {
        writerCategory.Dispose();
    }

    public int IndexCategories()
    {
        DataTable results = clta.GetCategoryAndLemmas();
        foreach(DataRow row in results.Rows)
        {
            IndexCategory(row);
        }
        DisposeCategory();
        return writerCategory.NumDocs();
    }
    
    private void IndexCategory(DataRow row)
    {
        Document document = GetCategoryDocument(row);
        writerCategory.AddDocument(document);
    }

    private Document GetCategoryDocument(DataRow row)
    {
        Document doc = new Document();
        doc.Add(new Field("CID", row["CategoryID"].ToString(), Field.Store.YES, Field.Index.NO));
        doc.Add(new Field("LID", row["LemmaID"].ToString(), Field.Store.YES, Field.Index.NO));
        doc.Add(new Field("Cname", row["Cname"].ToString(), Field.Store.YES, Field.Index.ANALYZED));
        doc.Add(new Field("title", row["Lname"].ToString(), Field.Store.YES, Field.Index.ANALYZED));

        return doc;
    }

    public int Index()
    {        
        DataTable results = lmta.GetLemmaAndMedia();
            foreach (DataRow name in results.Rows)
            {
                IndexFile(name);
            }
        
        Dispose();
        return writer.NumDocs();
        
    }

    private void IndexFile(DataRow name)
    {
        Document document = GetDocument(name);
        writer.AddDocument(document);
    }

    private Document GetDocument(DataRow name)
    {
        Document d = new Document();
        string content = name["Lname"] + ", " + name["Contect"];
        d.Add(new Field("title", name["Lname"].ToString(), Field.Store.YES, Field.Index.ANALYZED));
        d.Add(new Field("LID", name["LID"].ToString(), Field.Store.YES, Field.Index.NO));
        d.Add(new Field("Content", content, Field.Store.YES, Field.Index.ANALYZED));
        d.Add(new Field("MID", name["MID"].ToString(), Field.Store.YES, Field.Index.NO));
        d.Add(new Field("dataType", name["dataType"].ToString(), Field.Store.YES, Field.Index.ANALYZED));

        return d;
    }


    public String getIndexDirectory() { return IndexDirectory; }
    public String getDataDirectory() { return DataDirectory; }


}