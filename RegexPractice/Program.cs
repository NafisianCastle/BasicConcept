using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace RegexPractice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var patternText = @"^[a-zA-Z0-9\._-]{5,25}.@.[a-z]{2,12}.(com|org|co\.in|net)";

            //var reg = new Regex(patternText);

            ////When pattern matches
            //Console.WriteLine(reg.IsMatch("software_test123@gmail.com"));
            //Console.WriteLine(reg.IsMatch("Special.Char@yahoo.co.in"));

            ////When pattern doesnt match
            //Console.WriteLine(reg.IsMatch("ww.alsjk9874561230.mo@vie.dont"));



            var pattern = @"\b(?<FirstWord>\w+)\s?((\w+)\s)*(?<LastWord>\w+)?(?<Punctuation>\p{Po})";
            var input = "The cow jumped over the moon.";
            var rgx = new Regex(pattern);
            var match = rgx.Match(input);
            if (match.Success)
                ShowMatches(rgx, match);


            //string input = "1. Eggs 2. Bread 3. Milk 4. Coffee 52. Tea";
            //string pattern = @"\b\d{1,2}\.\s";
            ///*
            // *
            // * \b -     Begin the match at a word boundary.
            // * \d{1,2}	Match one or two decimal digits.
            // * \.	    Match a period.
            // * \s	    Match a white-space character.
            // *
            // */
            //foreach (string item in Regex.Split(input, pattern))
            //{
            //    if (!string.IsNullOrEmpty(item))
            //        Console.WriteLine(item);
            //}



            //string pattern = @"\b\d+(,\d{3})*\.\d{2}\b";
            //string input = "16.32\n194.03\n1,903,672.08";

            //foreach (Match match in Regex.Matches(input, pattern))
            //    Console.WriteLine(match.Result("$$ $&"));

            //string patternText = @"^[A-Z0-9a-z\._-]{5,25}.@.[a-z]{2,12}.(com|org|co\.in|net)";

            //Regex reg = new Regex(patternText);

            ////When pattern matches
            //Console.WriteLine(reg.IsMatch("software_test123@gmail.com"));
            //Console.WriteLine(reg.IsMatch("Special.Char@yahoo.co.in"));

            ////When pattern doesnt match
            //Console.WriteLine(reg.IsMatch("ww.alsjk9874561230.mo@vie.dont"));

        }



        private static void ShowMatches(Regex r, Match m)
        {
            var names = r.GetGroupNames();
            Console.WriteLine("Named Groups:");
            foreach (var name in names)
            {
                var grp = m.Groups[name];
                Console.WriteLine("   {0}: '{1}'", name, grp.Value);
            }
        }
    }
}
