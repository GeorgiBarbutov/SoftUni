using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndQueuesLab
{
    class SimpleCalculator
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();

            Stack<string> stack = new Stack<string>(input.Reverse());

            int result;

			while(stack.Count != 1)
            {
                int leftOperand = int.Parse(stack.Pop());
                string operation = stack.Pop();
                int rightOperand = int.Parse(stack.Pop());

                result = leftOperand;

				if(operation == "+")
                {
                    result += rightOperand;
                }
                if (operation == "-")
                {
                    result -= rightOperand;
                }

                stack.Push(result.ToString());
            }

            result = int.Parse(stack.Pop());

            Console.WriteLine(result);
        }
    }
}