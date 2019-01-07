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
using WindowsFormsApp1.ClassesForIndexer;
using static WindowsFormsApp1.InformatiCS_LibraryDataSet;
using System.Data.OleDb;

public class Indexer : IDisposable
{
    public String IndexDirectory = "Index";
    public String DataDirectory = "Data";

    private Lemma_MediaTableAdapter lmta = new Lemma_MediaTableAdapter();
    
    public Indexer()
    {
        Setup();
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

    private IndexWriter writer;

    public String getIndexDirectory() { return IndexDirectory; }
    public String getDataDirectory() { return DataDirectory; }


}