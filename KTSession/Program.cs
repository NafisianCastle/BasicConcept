//note this is .NET 4.7 and C# 7
using System;
using System.Net.NetworkInformation;

namespace KTSession
{   
    public class Program
    {
        static void Main(string[] args)
        {
            Employee.SetEmployeeSalary(500);
            

            var employee = new Employee
            {
                EmployeeID = 1
            };
            System.Console.WriteLine($"Employee ID: {employee.EmployeeID}\n");

            Employee.SetEmployeeSalary(800);
            var employee2 = new Employee
            {
                EmployeeID = 5
            };
            System.Console.WriteLine($"Employee ID: {employee2.EmployeeID}\n");
            
            var employee3 = new Employee
            {
                EmployeeID = 43
            };
            System.Console.WriteLine($"Employee ID: {employee3.EmployeeID} \n");

            System.Console.WriteLine();
            //const int constantVar = 5;
            //System.Console.WriteLine(constantVar);

            






























            
        }
    }

    public class Employee
    {
        public static int NumberOfEmployees { get;  set; } = 5;//note 
        public int EmployeeID { get; set; } 

        private static int _salary = 1000;
       // public static int Salary { get; set; }

       
        public int Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        public Employee()
        {
            System.Console.WriteLine("New Employee Added !!");
            NumberOfEmployees++;
            System.Console.WriteLine($"Number of employees: {NumberOfEmployees}");
            
           // NumberOfEmployees--;
        }


        //note you need static method only when you don't require any object state of that class.
        public static void SetEmployeeSalary(int value)
        {
            System.Console.WriteLine($"The base salary is: {_salary}");
            _salary+=value;
            System.Console.WriteLine($"The adjusted salary is: {_salary} with added amount : {value}");
        }

        
    }
}
