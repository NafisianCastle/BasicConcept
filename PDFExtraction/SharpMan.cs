using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Text;

namespace PDFExtraction
{
    internal class SharpMan
    {
        private readonly string _file;
        public SharpMan(string file)
        {
            _file = file;
        }
        public void Show()
        {
            var sb = new StringBuilder();
            try
            {
                using (var reader = new PdfReader(_file))
                {
                    for (var i = 1; i <= reader.NumberOfPages; i++)
                    {
                        ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                        var text = PdfTextExtractor.GetTextFromPage(reader, i, strategy);
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
