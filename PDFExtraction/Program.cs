namespace PDFExtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var file = @"C:/Users/Welldev/Downloads/resumetnr.pdf";

            var sharp = new SharpMan(file);
            sharp.Show();

            var iron = new IronMan(file);
            iron.Show();

        }
    }
}
