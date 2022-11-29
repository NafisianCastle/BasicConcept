using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Play
{
    public class OutExample
    {
        public (bool, int) TryParse(string valueToParse)
        {
            var success = int.TryParse(valueToParse, out var result);
            return (success, result);
        }

        public void ExampleOut(out int intValue)
        {
            intValue = 10;
        }

        public void ExampleOut(int intValue)
        {
            intValue = 10;

        }
    }
}
