using System;
using System.Linq;

namespace Multidimensional_Arrays_Exercise
{
    class MatrixOfPalindrones
    {
        static void Main(string[] args)
        {
            int[] rowsAndColums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rows = rowsAndColums[0];
            int colums = rowsAndColums[1];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
                    char firstAndLastLetter = (char)(97 + i);
                    char middleLetter = (char)(97 + j + i);
                    Console.Write($"{firstAndLastLetter}{middleLetter}{firstAndLastLetter} ");
                }
                Console.WriteLine();
            }
        }
    }
}
