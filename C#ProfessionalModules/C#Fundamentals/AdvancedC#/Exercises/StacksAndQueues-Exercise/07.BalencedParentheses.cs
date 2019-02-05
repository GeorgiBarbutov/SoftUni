using System;
using System.Collections.Generic;

namespace SoftUni_CSharp_Fundamentals_Exercises
{
    class BalancedPharenteses
    {
        static void Seventh(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            bool isBalanced = true;

            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] == '(' || input[i] == '{' || input[i] == '[')
                {
                    stack.Push(input[i]);
                }
                
                if(input[i] == ')')
                {
                    if(stack.Count == 0 || stack.Peek() != '(')
                    {
                        isBalanced = false;
                        break;
                    }
                    else if(stack.Peek() == '(')
                    {
                        stack.Pop();
                    }
                }
                if (input[i] == ']')
                {
                    if (stack.Count == 0 || stack.Peek() != '[')
                    {
                        isBalanced = false;
                        break;
                    }
                    else if (stack.Peek() == '[')
                    {
                        stack.Pop();
                    }
                }
                if (input[i] == '}')
                {
                    if (stack.Count == 0 || stack.Peek() != '{')
                    {
                        isBalanced = false;
                        break;
                    }
                    else if (stack.Peek() == '{')
                    {
                        stack.Pop();
                    }
                }
            }

            if(isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
