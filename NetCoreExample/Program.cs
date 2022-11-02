//note this is .NET 6 and C# 10
public class Program
{
    static void Main(string[] args)
    {
        Employee employee = new()
        {
            EmployeeID = 1
        };
        Console.WriteLine($"Employee ID: {employee.EmployeeID}");

        var employee2 = new Employee();
        employee2.EmployeeID = 5;
        Console.WriteLine($"Employee ID: {employee2.EmployeeID}");

        Employee employee3 = new();
        employee3.EmployeeID = 43;
        //employee3.NumberOfEmployees = 5;
        Console.WriteLine($"Employee ID: {employee3.EmployeeID}");
    }
}

public class Employee
{
    //public  int NumberOfEmployees { get; init; } //note init let us to assign value only once.
    public static int NumberOfEmployees { get; set; }
    //public  int NumberOfEmployees { get; private set; }
    public int EmployeeID { get; set; }

    public Employee()
    {
        Console.WriteLine("New Employee Added !!");
        NumberOfEmployees++;
        Console.WriteLine($"Number of employees: {NumberOfEmployees}");
        // NumberOfEmployees--;
        //NumberOfEmployees++;
    }


}

