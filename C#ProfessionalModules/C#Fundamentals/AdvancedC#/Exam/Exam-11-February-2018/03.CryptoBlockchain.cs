using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CryptoBlockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string wholeInput = String.Empty;

            for (int i = 0; i < n; i++)
            {
                string oneLineInput = Console.ReadLine();
                wholeInput += oneLineInput;
            }

            Regex blockChainRegex = new Regex(@"{[ -~]*?}|\[[ -~]*?\]");
            Regex numberRegex = new Regex("[0-9]+");

            MatchCollection blockChainMatches = blockChainRegex.Matches(wholeInput);

            string[] blockChain = new string[blockChainMatches.Count];

            List<string> numbers = new List<string>();
            List<int> cryptoBlockLength = new List<int>();

            for (int i = 0; i < blockChainMatches.Count; i++)
            {               
                blockChain[i] = blockChainMatches[i].ToString();

                var numbersMatches = numberRegex.Matches(blockChain[i]);

                if(numbersMatches.Count == 1)
                {
                    if (numbersMatches[0].Length % 3 == 0)
                    {
                        cryptoBlockLength.Add(blockChain[i].Length);

                        numbers.Add(numbersMatches[0].ToString());
                    }
                }
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 0; j < numbers[i].Length; j+=3)
                {
                    char output = (char)(((int)numbers[i][j] - 48) * 100 + ((int)numbers[i][j + 1] - 48) * 10 + ((int)numbers[i][j + 2] - 48) - cryptoBlockLength[i]);
                    Console.Write(output);
                }
            }
        }
    }
}
