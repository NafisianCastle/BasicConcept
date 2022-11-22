using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFExtraction
{
    internal class SharpMan
    {
        private string _file;
        public SharpMan(string file) {
            _file = file;
        }
        public void Show()
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (PdfReader reader = new PdfReader(_file))
                {
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                        string text = PdfTextExtractor.GetTextFromPage(reader, i, strategy);
                        text = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(text)));

                        sb.Append(text);
                    }
                }

                Console.WriteLine(sb.ToString());
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

    }
}
