using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPdf;
namespace PDFExtraction
{
    internal class IronMan
    {
        private string _file;
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

                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
