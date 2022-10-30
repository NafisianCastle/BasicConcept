using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPDemo.Data;

namespace OOPDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Person person = new Student();
            
            Console.WriteLine("Enter which type of person you want to entry (1. Student 2. Teacher 3.Others)");
            var x = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Name");
            var name = Console.ReadLine();

            Console.WriteLine ("Enter Age");
            var age = Convert.ToInt32(Console.ReadLine());
            while (age < 0 || age>100)
            {
                Console.WriteLine("Please enter valid age...");
                age = Convert.ToInt32(Console.ReadLine());
            }
            if (x == 1)
            {
                Student student = new Student();
                student.Name = name;
                student.Age = age; 
                Console.WriteLine("Enter your Department");
                var department = Console.ReadLine();
                while (!Departments.IsDefined(typeof(Departments), department))
                {
                    Console.WriteLine("Please enter valid department...");
                    department = Console.ReadLine();
                }
                student.Department = department;
            }
            else
            {
                Console.WriteLine("Enter your designation");
                var designation = Console.ReadLine();
            }


            string sourceFilePath = @"C:\MyData\TestFile.txt";
            bool doesFileExist = File.Exists(sourceFilePath);
            Console.WriteLine(doesFileExist);
        }
    }
}
