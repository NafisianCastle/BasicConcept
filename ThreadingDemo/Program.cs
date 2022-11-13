using System;
using System.Threading;

namespace ThreadingDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var threadStartDelegate = new ThreadStart(PrintYourAge);
            //var delegateInstance = new Thread(threadStartDelegate);

            var t1 = new Thread(PrintYourAge);
            var t2 = new Thread(GetTotalAge);

            t1.Start();
            t1.Join();

            t2.Start(21);

            Console.ReadKey();
        }

        public static void GetTotalAge(object numberOrdered)
        {
            int ordersCount;
            if (int.TryParse(numberOrdered.ToString(), out ordersCount))
            {
                int totalCost = 175 * ordersCount;
                Console.WriteLine("the total cost is: " + totalCost);
            }
            else { Console.WriteLine("Error"); }
        }

        public static void PrintYourAge()
        {
            Console.WriteLine("Product Unit Price: $175");
        }

    }
}
