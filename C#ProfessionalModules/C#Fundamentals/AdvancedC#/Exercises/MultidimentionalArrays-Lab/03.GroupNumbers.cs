using System;
using System.Collections.Generic;
using System.Linq;

namespace Multidimensional_Arrays___Lab
{
    class GroupNumbers
    {
        static void Third(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None).Select(int.Parse).ToArray(); 

            List<int>[] groups = new List<int>[3];

            groups[0] = new List<int>();
            groups[1] = new List<int>();
            groups[2] = new List<int>();

            foreach (int number in numbers)
            {
                if (Math.Abs(number % 3) == 0)
                {
                    groups[0].Add(number);
                }
                else if (Math.Abs(number % 3) == 1)
                {
                    groups[1].Add(number);
                }
                else if (Math.Abs(number % 3) == 2)
                {
                    groups[2].Add(number);
                }
            }

            Console.WriteLine(String.Join(" ", groups[0]));
            Console.WriteLine(String.Join(" ", groups[1]));
            Console.WriteLine(String.Join(" ", groups[2]));
        }
    }
}
