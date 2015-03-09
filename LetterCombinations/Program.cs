using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LetterCombinations
{
    class Program
    {
        //Create list to hold results
        static List<string> results = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Input desired word(s)(Whitespace will be ignored).");
            //Get Input
            string input = Console.ReadLine().ToString();
            //Remove whitespace
            input = Regex.Replace(input, @"\s+", "");
            //Call recursive function
            permutation("", input, input.Length);

            //Write results to file
            System.IO.File.WriteAllLines(@"output.txt", results);

        }

        private static void permutation(string prefix, string str, int origLength)
        {


            int length = str.Length;
            if (length == 0)
            {
                results.Add(prefix);
            }
            else
            {   //Filter out results that aren't the same length as the original word
                if (prefix.Length == origLength)
                {
                    results.Add(prefix);
                }

                for (int i = 0; i < length; i++)
                {
                    permutation(prefix + str[i], str.Substring(0, i) + str.Substring(i + 1), origLength);
                }
            }
        }
    }
}
