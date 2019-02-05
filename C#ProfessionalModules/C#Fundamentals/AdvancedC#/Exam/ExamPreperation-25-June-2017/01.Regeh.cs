using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> indexers = new List<int>();

            string input = Console.ReadLine();

            Regex regeh = new Regex(@"\[\w+<(\d+)REGEH(\d+)>\w+\]");

            MatchCollection allMatches = regeh.Matches(input);

            for (int i = 0; i < allMatches.Count; i++)
            {
                int firstNumber = int.Parse(allMatches[i].Groups[1].ToString());
                int secondNumber = int.Parse(allMatches[i].Groups[2].ToString());

                indexers.Add(firstNumber);
                indexers.Add(secondNumber);
            }

            int previousIndex = 0;

            foreach (var index in indexers)
            {
                int currentIndex = previousIndex + index;

                if(currentIndex >= input.Length)
                {
                    currentIndex -= input.Length;
                }

                Console.Write(input[currentIndex]);

                previousIndex = currentIndex;
            }
        }
    }
}
