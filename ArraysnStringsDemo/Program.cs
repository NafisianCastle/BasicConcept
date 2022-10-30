using System;
using System.Linq;

namespace ArraysnStringsDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var arrObj = new ArrayDemo();
            arrObj.ArrayExample();

            Console.WriteLine("\n");

            var strObj = new StringDemo();
            strObj.StringExample();

            Console.ReadLine();
        }
    }
}
