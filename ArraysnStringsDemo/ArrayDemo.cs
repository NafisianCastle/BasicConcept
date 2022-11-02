using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysnStringsDemo
{
    public class ArrayDemo
    {
        public void ArrayExample()
        {
            /* One Dimensional Array */

            int[] arr1 = new int[10];
            int len = arr1.Length;



            var arr2 = new int[] { 2, 3, 4, 56, 8, 7 };
            var aggregatedValue = arr2.Aggregate(5, (a, b) => a + b);  //here 5 is the seed value. the accumulator initiate with seed value and do the operation accordin to lambda expression.
            Console.WriteLine(aggregatedValue);

            var allChecker = arr2.All(val => val > 4); //checks the condition in whole array. 
            Console.WriteLine(allChecker);

            var hasAnyValue = arr2.Any(val => val.Equals(2));
            Console.WriteLine($"if the array has this value? : {hasAnyValue}");

            var avgValue = arr2.Average();
            Console.WriteLine("Average of values of this array: " + avgValue);


            var x = arr2.Where(val => val > 4).Take(1);
            Console.WriteLine(x.First());
            Console.WriteLine();


            var distinctVal = arr2.Distinct();
            foreach (var val in distinctVal)
                Console.Write(val + " ");

            //object[] arr3 = new object[5];

            short[] arr3 = new Int16[5];
            Int16[] arr4 = new short[5];
            long[] arr5 = new Int64[5];


            int[] arr6 = { 2, 3, 4, 5, 6 };


            /* Two Dimensional Array */

            int[,] multiarr1 = new int[2, 4];
            multiarr1[0, 0] = 1;
            //multiarr1[4,5] = 2; // we can actually assign value out of range. Although it'll not cause any Compile time exception, it'll cause an IndexOutOfRangeException in Runtime.

            int[,] multiarr2 = { { 1, 2, 3 }, { 2, 54, 3 } };

            int[,,] ThreeDarr = new int[2, 5, 3];

            /* Jagged array */
            int[][] jaggedarr = new int[2][];

            jaggedarr[0] = arr1;
            jaggedarr[1] = new int[4] { 2, 3, 4, 5 };


            


        }
    }
}
