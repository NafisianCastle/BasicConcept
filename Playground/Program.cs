using System;

namespace Playground
{
    delegate T ParamDel<T>();
    
    public class Program
    {

        static void Main(string[] args)
        {
            PartialDemo pd = new PartialDemo
            {
                FirstName = "Tanveer",
                LastName = "Zaman",
                City = "Dhaka",
                Province = "Dhaka",
                Country = "Bangladesh"
            };

            var msg = pd.PersonalDetails(fullName: new ParamDel<string>(pd.FullName), address: new ParamDel<string>(pd.Address));
            Console.WriteLine(msg);

        }
    }
}
