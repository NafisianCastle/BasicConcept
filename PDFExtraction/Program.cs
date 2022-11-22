using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFExtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            string file = @"C:/Users/Welldev/Downloads/resumetnr.pdf";

            SharpMan sharp = new SharpMan(file);
            sharp.Show();

            IronMan iron = new IronMan(file);
            iron.Show();

        }
    }
}
