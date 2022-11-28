using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompressionExtractionDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string startPath = @".\start";
            const string zipPath = @".\result.zip";
            const string extractPath = @".\extract";

            ZipFile.CreateFromDirectory(startPath, zipPath);

            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}
