using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_CSharp_Fundamentals_Labs
{
    class StacksAndQueuesLab1
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            foreach (var character in input)
            {
                stack.Push(character);
            }

            while (stack.Count != 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}