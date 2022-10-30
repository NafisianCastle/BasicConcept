using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructnEnumsDemo
{
    public struct Rectangle
    {
        public int width, height;
    }
    internal class Program
    {
        public enum Season { WINTER, SPRING, SUMMER, FALL }
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle();
            r.width = 4;
            r.height = 5;
            Console.WriteLine("Area of Rectangle is: " + (r.width * r.height));

            var season = Season.WINTER;
            Console.WriteLine(season);
            Console.WriteLine();


            foreach (var item in Enum.GetValues(typeof(Season)))
            {
                Console.WriteLine(item);
            }

        }
    }
}
