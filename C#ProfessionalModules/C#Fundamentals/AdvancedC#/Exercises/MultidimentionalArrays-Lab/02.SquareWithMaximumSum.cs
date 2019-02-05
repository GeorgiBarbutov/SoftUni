using System;
using System.Linq;

namespace Multidimensional_Arrays___Lab
{
    class SquareWithMaximumSum
    {
        static void Second(string[] args)
        {
            int[] rowAndCollumInput = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None).Select(int.Parse).ToArray();

            int row = rowAndCollumInput[0];
            int collum = rowAndCollumInput[1];

            int[][] matrix = new int[row][];

            InitializeArray(matrix, row);

            FindLargestSubmatrix(matrix);
        }

        private static void FindLargestSubmatrix(int[][] matrix)
        {
            int maxSum = 0;
            int[][] largestSubmatrix = new int[2][];

            largestSubmatrix[0] = new int[] { 0, 0 };
            largestSubmatrix[1] = new int[] { 0, 0 };

            for (int i = 0; i < matrix.Length - 1; i++)
            {
                for (int j = 0; j < matrix[i].Length - 1; j++)
                {
                    int currentSum = 0;
                    currentSum += matrix[i][j] + matrix[i][j + 1] + matrix[i + 1][j] + matrix[i + 1][j + 1];

                    if(currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        largestSubmatrix[0][0] = matrix[i][j];
                        largestSubmatrix[0][1] = matrix[i][j + 1];
                        largestSubmatrix[1][0] = matrix[i + 1][j];
                        largestSubmatrix[1][1] = matrix[i + 1][j + 1];
                    }
                }
            }

            PrintLargestSubmatrix(largestSubmatrix, maxSum);
        }

        private static void PrintLargestSubmatrix(int[][] largestSubmatrix, int maxSum)
        {
            for (int i = 0; i < largestSubmatrix.Length; i++)
            {
                for (int j = 0; j < largestSubmatrix[i].Length; j++)
                {
                    Console.Write(largestSubmatrix[i][j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }

        private static void InitializeArray(int[][] matrix, int row)
        {
            for (int i = 0; i < row; i++)
            {
                int[] elementsPerRow = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None).Select(int.Parse).ToArray();

                matrix[i] = new int[elementsPerRow.Length];

                for (int j = 0; j < elementsPerRow.Length; j++)
                {
                    matrix[i][j] = elementsPerRow[j];
                }
            }
        }
    }
}
