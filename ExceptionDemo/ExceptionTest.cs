using System;

namespace ExceptionDemo
{
    public class ExceptionTest
    {
        public void Experiment()
        {
            try
            {
                Console.WriteLine("I am trying");
                try
                {
                    Console.WriteLine("I am trying in trying");
                    int a = 5;
                    int b = 0;
                    int x = a / b;
                    Console.WriteLine("the value is :{0}", x);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("I caught you for {0}!", ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    Console.WriteLine(ex.InnerException);
                    Console.WriteLine(ex.TargetSite);
                    Console.WriteLine(ex.HelpLink);
                    Console.WriteLine(ex.Data);
                }
                //throw new Exception();
                throw new ArgumentException();
            }

            catch (Exception ex)
            {
                Console.WriteLine("I caught you for {0}!", ex.Message);
            }
            try
            {
                Console.WriteLine("I am trying again.");
                //throw new Exception();
            }
            finally
            {
                Console.WriteLine("Finally, It's done.");
            }









        }
    }
}
