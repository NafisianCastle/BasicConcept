using System;
using System.IO;
using System.Linq;

namespace FileIODemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CopyDirectory(@".\", @".\copytest", true);

            //try
            //{
            //    // Set a variable to the My Documents path.
            //    string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //    List<string> dirs = new List<string>(Directory.EnumerateDirectories(docPath));

            //    foreach (var dir in dirs)
            //    {
            //        Console.WriteLine($"{dir.Substring(dir.LastIndexOf(Path.DirectorySeparatorChar) + 1)}");
            //    }
            //    Console.WriteLine($"{dirs.Count} directories found.");
            //}
            //catch (UnauthorizedAccessException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch (PathTooLongException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}


            try
            {
                // Set a variable to the My Documents path.
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                var files = from file in Directory.EnumerateFiles(docPath, "*.txt", SearchOption.AllDirectories)
                            from line in File.ReadLines(file)
                            where line.Contains("Microsoft")
                            select new
                            {
                                File = file,
                                Line = line
                            };

                foreach (var f in files)
                {
                    Console.WriteLine($"{f.File}\t{f.Line}");
                }
                Console.WriteLine($"{files.Count()} files found.");
            }
            catch (UnauthorizedAccessException uAEx)
            {
                Console.WriteLine(uAEx.Message);
            }
            catch (PathTooLongException pathEx)
            {
                Console.WriteLine(pathEx.Message);
            }

        }


        static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }
    }
}
