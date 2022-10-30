using System;

namespace Playground
{
    delegate T ThreeParamDel<T>(T a, T b, T c);
    delegate T TwoParamDel<T>(T x, T y);
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

            //var fullName = pd.FullName(pd.FirstName, pd.LastName);
            //var address = pd.Address(pd.City, pd.Province, pd.Country);
            var msg = pd.PersonalDetails(fullName: new TwoParamDel<string>(pd.FullName), address: new ThreeParamDel<string>(pd.Address));

            //Console.WriteLine(fullName);
            //Console.WriteLine(address);
            Console.WriteLine(msg);

        }
    }
}
