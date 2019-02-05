using System;
using System.Linq;

namespace _04.Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int lowerBound = bounds[0];
            int upperBound = bounds[1];

            string command = Console.ReadLine();

            Action<int, int> filter = CreateFilter(command);

            filter(lowerBound, upperBound);
        }

        static Action<int, int> CreateFilter (string command)
        {
            if(command == "odd")
            {
                return (lower, upper) =>
                {
                    for (int i = lower; i <= upper; i++)
                    {
                        if (i % 2 == 1 || i % 2 == -1)
                        {
                            Console.Write(i + " ");
                        }
                    }
                };
            }
            else
            {
                return (lower, upper) =>
                {
                    for (int i = lower; i <= upper; i++)
                    {
                        if (i % 2 == 0)
                        {
                            Console.Write(i + " ");
                        }
                    }
                };
            }
        }
    }
}
