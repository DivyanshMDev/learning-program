using System;


public abstract class DocumentFactory
{

    public abstract Document CreateDocument();


    public void ProcessDocument()
    {
        Document doc = CreateDocument();
        doc.Open();
        doc.Save();
        doc.Close();
    }
}
