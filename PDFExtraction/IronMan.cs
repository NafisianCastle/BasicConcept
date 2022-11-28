using IronPdf;
using System;
using System.Collections.Generic;
namespace PDFExtraction
{
    internal class IronMan
    {
        private readonly string _file;
        public IronMan(string file)
        {
            _file = file;
        }

        public void Show()
        {
            try
            {
                //using (PdfDocument Pdf = new PdfDocument.FromFile(_file))
                //{
                //    var allText = Pdf.ExtracAllText();
                //    Console.WriteLine(allText);
                //}
                var Renderer = new ChromePdfRenderer(); // Instantiates Chrome Renderer
                var pdf = Renderer.RenderHtmlAsPdf(" <h1> ~Hello World~ </h1> Made with IronPDF!");
                pdf.SaveAs(@"C:\Users\Welldev\Desktop\pdfs\html_saved.pdf"); // Saves our PdfDocument object as a PDF


                Renderer.RenderingOptions.CssMediaType = IronPdf.Rendering.PdfCssMediaType.Screen;

                var pdf2 = Renderer.RenderUrlAsPdf("https://getbootstrap.com/");
                pdf2.SaveAs(@"C:\Users\Welldev\Desktop\pdfs\url_saved.pdf");


                var pdf3 = PdfDocument.FromFile(_file);

                //Get all text to put in a search index
                var AllText = pdf.ExtractAllText();

                //Get all Images
                var AllImages = pdf3.ExtractAllImages();

                //Or even find the precise text and images for each page in the document
                for (var index = 0; index < pdf3.PageCount; index++)
                {
                    var PageNumber = index + 1;
                    var Text = pdf.ExtractTextFromPage(index);
                    var Images = pdf3.ExtractImagesFromPage(index);
                    ///...
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
