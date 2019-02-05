using System;
using System.Linq;

namespace Multidimensional_Arrays_Exercise
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] numbers = new int[n,n];

            for (int i = 0; i < n; i++)
            {
                int[] matrixRowNumbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < n; j++)
                {
                    numbers[i, j] = matrixRowNumbers[j];
                }
            }

            int mainDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        mainDiagonalSum += numbers[i, j];
                    }
                    if(i + j == n - 1)
                    {
                        secondaryDiagonalSum += numbers[i, j];
                    }
                }
            }

            int totalAbsoluteDifference = Math.Abs(mainDiagonalSum - secondaryDiagonalSum);

            Console.WriteLine(totalAbsoluteDifference);
        }
    }
}
