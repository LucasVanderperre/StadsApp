using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.Controllers
{
    public class PDFController
    {
        public void PrintFile()
        {
            FileStream fs = new FileStream("PDFNAME.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.AddTitle("Kortingsbon");
            doc.Open();
            doc.Add(new Paragraph("Kortingsbon voor de promotie "));
            doc.Close();
            writer.Close();
            fs.Close();


        }




    }
}
