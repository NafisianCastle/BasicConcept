using System;
using System.Text.RegularExpressions;

namespace REgexDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\s|^)[Nn]afis(\s|$)";
            Console.WriteLine("Nafisur Rahman: " + Regex.IsMatch("Nafisur Rahman", pattern));
            Console.WriteLine("nafisur Rahman: " + Regex.IsMatch("nafisur Rahman", pattern));
            Console.WriteLine("Rahman nafis ur: " + Regex.IsMatch("Rahman nafis ur", pattern));
        }
    }
}
