using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_CSharp_Fundamentals_Labs
{
    class MatchingBrackets
    {
		static void Main()
        {
            string input = Console.ReadLine();

            var stack = new Stack<int>();

            int openingBracketIndex, closingBracketIndex;

            for (int i = 0; i < input.Length; i++)
            {
				if(input[i] == '(')
                {
                    stack.Push(i);
                }

				if(input[i] == ')')
                {
                    closingBracketIndex = i;
                    openingBracketIndex = stack.Pop();

                    for (int j = openingBracketIndex; j <= closingBracketIndex; j++)
                    {
                        Console.Write(input[j]);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
