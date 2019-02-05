using System;
using System.Linq;

namespace _09.List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] diveders = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            Func<int, int[], bool> isDivisable = (number, arrayOfDiveders) =>
            {
                foreach (var divider in arrayOfDiveders)
                {
                    if(number % divider != 0)
                    {
                        return false;
                    }
                }

                return true;
            };

            for (int i = 1; i <= n; i++)
            {
                if(isDivisable(i, diveders))
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
