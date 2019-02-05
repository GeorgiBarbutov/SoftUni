using System;
using System.Linq;

namespace Multidimensional_Arrays_Exercise
{
    class SquaresInMatrix
    {
        static void Main(string[] args)
        {
            int[] rowsAndColums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rows = rowsAndColums[0];
            int colums = rowsAndColums[1];

            char[][] matrix = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                char[] matrixRowChars = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                matrix[i] = new char[colums];

                for (int j = 0; j < colums; j++)
                {
                    matrix[i][j] = matrixRowChars[j];
                }
            }

            int sum = 0;

            for (int i = 0; i < matrix.Length - 1; i++)
            {
                for (int j = 0; j < matrix[i].Length - 1; j++)
                {
                    char currentLetter = matrix[i][j];

                    if(currentLetter == matrix[i][j + 1] && currentLetter == matrix[i + 1][j] && currentLetter == matrix[i + 1][j + 1])
                    {
                        sum++;
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
