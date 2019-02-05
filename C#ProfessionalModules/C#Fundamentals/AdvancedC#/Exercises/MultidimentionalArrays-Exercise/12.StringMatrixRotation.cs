using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _12.String_Matrix_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            Regex regex = new Regex("[0-9]+");

            int degrees = int.Parse(regex.Match(command).ToString()) % 360;

            List<string> words = new List<string>();

            string word;

            int biggestWordLength = 0;

            while((word = Console.ReadLine()) != "END")
            {
                words.Add(word);

                if(word.Length > biggestWordLength)
                {
                    biggestWordLength = word.Length;
                }
            }
                      
            for (int i = 0; i < words.Count; i++)
            {
                int currentWordLength = words[i].Length;

                for (int j = 0; j < biggestWordLength - currentWordLength; j++)
                {
                    words[i] += " ";
                }
            }

            if(degrees == 90)
            {
                for (int j = 0; j < words[0].Length; j++)
                {
                    for (int i = words.Count - 1; i >= 0; i--)
                    {
                        Console.Write(words[i][j]);
                    }
                    Console.WriteLine();
                }
            }
            if (degrees == 180)
            {
                for (int i = words.Count - 1; i >= 0; i--)
                {
                    for (int j = words[0].Length - 1; j >= 0; j--)
                    {
                        Console.Write(words[i][j]);
                    }
                    Console.WriteLine();
                }
            }
            if (degrees == 270)
            {
                for (int j = words[0].Length - 1; j >= 0; j--)
                {
                    for (int i = 0; i < words.Count; i++)
                    {
                        Console.Write(words[i][j]);
                    }
                    Console.WriteLine();
                }
            }
            if(degrees == 0)
            {
                for (int i = 0; i < words.Count; i++)
                {
                    for (int j = 0; j < words[0].Length; j++)
                    {
                        Console.Write(words[i][j]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
