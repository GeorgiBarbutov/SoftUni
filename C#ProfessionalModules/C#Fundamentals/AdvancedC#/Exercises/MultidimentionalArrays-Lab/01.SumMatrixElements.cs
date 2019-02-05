using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multidimensional_Arrays___Lab
{
    class SumMatrixElements
    {
        static void First(string[] args)
        {
           int[] rowAndCollumInput = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None).Select(int.Parse).ToArray();
           
           int row = rowAndCollumInput[0];
           int collum = rowAndCollumInput[1];
           
           int[,] matrix = new int[row, collum];
           
           for (int i = 0; i < row; i++)
           {
               int[] elementsPerRow = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None).Select(int.Parse).ToArray();
           
               for (int j = 0; j < elementsPerRow.Length; j++)
               {
                   matrix[i, j] = elementsPerRow[j];
               }
           }
           
           Console.WriteLine(row);
           Console.WriteLine(collum);
           
           int sum = 0;
           
           foreach (var item in matrix)
           {
               sum += item;
           }
           
           Console.WriteLine(sum);
        }
    }
}
