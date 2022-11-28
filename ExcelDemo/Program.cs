using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace ExcelDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var file = new FileInfo(@"C:/Users/Welldev/Downloads/demo.xlsx");

            var people = GetSetupData();

            await SaveExcelFile(people, file);

            var personsFromExcel = await LoadExcelFile(file);

            PrintExcelData(personsFromExcel);
        }

        private static void PrintExcelData(List<PersonModel> personsFromExcel)
        {
            foreach (var person in personsFromExcel)
            {
                Console.WriteLine($"{person.Id} {person.FirstName} {person.LastName}");
            }
        }

        private static async Task<List<PersonModel>> LoadExcelFile(FileInfo file)
        {
            using var package = new ExcelPackage(file);

            await package.LoadAsync(file);

            var ws = package.Workbook.Worksheets[0];

            var row = 3;
            var col = 1;

            List<PersonModel> output = new();
            while (string.IsNullOrWhiteSpace(ws.Cells[row, col].Value?.ToString()) == false)
            {
                PersonModel p = new()
                {
                    Id = int.Parse(ws.Cells[row, col].Value.ToString()),
                    FirstName = ws.Cells[row, col + 1].Value.ToString(),
                    LastName = ws.Cells[row, col + 2].Value.ToString()
                };
                output.Add(p);
                row++;
            }
            return output;
        }

        private static async Task SaveExcelFile(List<PersonModel> people, FileInfo file)
        {
            DeleteIfExists(file);

            using var package = new ExcelPackage(file);
            var ws = package.Workbook.Worksheets.Add("MainReport");

            var range = ws.Cells["A2"].LoadFromCollection(people, true);
            range.AutoFitColumns();

            //format the header
            ws.Cells["A1"].Value = "Our cool report";
            ws.Cells["A1:C1"].Merge = true;

            ws.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Row(1).Style.Font.Size = 24;
            ws.Row(1).Style.Font.Color.SetColor(Color.Blue);

            ws.Row(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Row(2).Style.Font.Bold = true;

            ws.Column(3).Width = 20;

            await package.SaveAsync();
        }

        private static void DeleteIfExists(FileInfo file)
        {
            if (file.Exists)
            {
                file.Delete();
            }
        }

        private static List<PersonModel> GetSetupData()
        {
            List<PersonModel> output = new()
            {
                new()  {Id=1, FirstName="Nafis" , LastName="Rahman"},
                new()  {Id=2, FirstName="Arnob" , LastName="Ali"},
                new()  {Id=3, FirstName="Rawnak" , LastName="Yazdani"},
            };
            return output;
        }
    }
}
