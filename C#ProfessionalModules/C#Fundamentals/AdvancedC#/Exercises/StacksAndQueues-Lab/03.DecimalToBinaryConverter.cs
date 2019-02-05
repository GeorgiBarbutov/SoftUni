using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndQueuesLab
{
    class DecimalToBinary
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            if (input == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Stack<int> stack = new Stack<int>();

                while (input != 0)
                {
                    int remainder = input % 2;

                    input /= 2;

                    stack.Push(remainder);
                }

                while (stack.Count != 0)
                {
                    Console.Write(stack.Pop());
                }
            }
        }
    }
}