using System;
using System.Linq;

namespace _06.Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            int divider = int.Parse(Console.ReadLine());

            Func<int[], int[]> reverseFunction = x =>
            {
                for (int i = 0; i < x.Length / 2; i++)
                {
                    int temp = x[i];
                    x[i] = x[x.Length - 1 - i];
                    x[x.Length - 1 - i] = temp;
                }

                return x;
            };

            Func<int, bool> IsDevisible = CreateCheckForDivisability(divider);

            numbers = reverseFunction(numbers);

            foreach (var number in numbers)
            {
                if(!IsDevisible(number))
                {
                    Console.Write(number + " ");
                }
            }
        }

        private static Func<int, bool> CreateCheckForDivisability(int divider)
        {
            return x => x % divider == 0;
        }
    }
}
