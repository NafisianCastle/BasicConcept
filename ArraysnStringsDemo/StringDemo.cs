using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysnStringsDemo
{
    public class StringDemo
    {
        public void StringExample()
        {
            string filePath = @"C:\Users\scoleridge\Documents\";
            Console.WriteLine(filePath);
           

            string text = @"My pensive SARA ! thy soft cheek reclined
    Thus on mine arm, most soothing sweet it is
    To sit beside our Cot,...";
            Console.WriteLine(text);
           

            string quote = @"Her name was ""Sara.""";
            Console.WriteLine(quote);
           

            string alert = "this is \a alert";
            Console.WriteLine(alert);
        }
    }
}
