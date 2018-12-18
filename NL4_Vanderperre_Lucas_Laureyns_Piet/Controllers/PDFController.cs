using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.qrcode;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Data;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Models;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using ZXing;
using ZXing.QrCode;
using ZXing.Rendering;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.Controllers
{
    public class PDFController
    {
        public async  Task PrintFile(Promotie promotie)
        {
            
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync(string.Format(@"{0}.pdf", Guid.NewGuid()),
                    Windows.Storage.CreationCollisionOption.ReplaceExisting);
           
            string path = sampleFile.Path;
            var pdfDoc = new Document(PageSize.LETTER, 40f, 40f, 60f, 60f);
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate);

            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
            pdfDoc.Open();

            pdfDoc.AddTitle("Kortingsbon");
            pdfDoc.Add(new Paragraph("Kortingsbon voor de promotie "+ promotie.Naam));
            pdfDoc.Add(new Paragraph("Deze bon is geldig van "+ promotie.Startdatum.ToShortDateString() +
                " tot " +promotie.Einddatum.ToShortDateString()));
            pdfDoc.Add(new Paragraph("De code van deze bon: "+ promotie.Barcode));



            //BarcodeEAN barcode = new BarcodeEAN();
            //barcode.CodeType = (Barcode.EAN8);
            //barcode.Code = ("abcde");
            //pdfDoc.Add(barcode.CreateImageWithBarcode(writer.DirectContent, BaseColor.BLACK, BaseColor.GRAY));

            //var wrt = new BarcodeWriter();
            //wrt.Format = BarcodeFormat.QR_CODE;
            //var qr = new ZXing.BarcodeWriter();
            //qr.Options = new QrCodeEncodingOptions
            //{
            //    DisableECI = true,
            //    CharacterSet = "UTF-8",
            //    Width = 250,
            //    Height = 250,
            //};
            //qr.Format = ZXing.BarcodeFormat.QR_CODE;
            //var result = (qr.Write("teststring"));

            //var wrt = new ZXing.BarcodeWriter
            //{
            //    Format = ZXing.BarcodeFormat.QR_CODE,
            //    Options = new ZXing.Common.EncodingOptions
            //    {
            //        Height = 300,
            //        Width = 300
            //    },
            //    Renderer = new WriteableBitmapRenderer() { Foreground = Windows.UI.Colors.Black }
            //};
            //var writeableBitmap = wrt.Write("teststring");




            pdfDoc.Close();

            await Windows.System.Launcher.LaunchFileAsync(sampleFile);



           
            
        }




    }
}
