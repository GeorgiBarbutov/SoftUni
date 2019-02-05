using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multidimensional_Arrays_Exercise
{
    class MaximumSum
    {
        static void Main(string[] args)
        {
            int[] rowsAndColums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rows = rowsAndColums[0];
            int colums = rowsAndColums[1];

            int[][] matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] matrixRowChars = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                matrix[i] = new int[colums];

                for (int j = 0; j < colums; j++)
                {
                    matrix[i][j] = matrixRowChars[j];
                }
            }

            int maxSum = int.MinValue;
            int[][] maxMatrix = new int[3][];

            maxMatrix[0] = new int[] { int.MinValue, int.MinValue, int.MinValue };
            maxMatrix[1] = new int[] { int.MinValue, int.MinValue, int.MinValue };
            maxMatrix[2] = new int[] { int.MinValue, int.MinValue, int.MinValue };

            for (int i = 0; i < matrix.Length - 2; i++)
            {
                for (int j = 0; j < matrix[i].Length - 2; j++)
                {
                    int currentSum = matrix[i][j] + matrix[i][j + 1] + matrix[i][j + 2] + matrix[i + 1][j] + matrix[i + 1][j + 1] + matrix[i + 1][j + 2] + matrix[i + 2][j] + matrix[i + 2][j + 1] + matrix[i + 2][j + 2];

                    if(currentSum > maxSum)
                    {
                        maxSum = currentSum;

                        for (int k = 0; k < 3; k++)
                        {
                            for (int l = 0; l < 3; l++)
                            {
                                maxMatrix[k][l] = matrix[i + k][j + l];
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(maxMatrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
