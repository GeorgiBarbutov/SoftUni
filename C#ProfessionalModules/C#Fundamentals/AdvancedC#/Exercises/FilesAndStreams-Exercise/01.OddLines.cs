using System;
using System.IO;

namespace _01.Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("../../../Resorces/text.txt");

            using (reader)
            {
                int lineCount = 0;

                string line;

                while((line = reader.ReadLine()) != null)
                {
                    if(lineCount % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }

                    lineCount++;
                }
            }
        }
    }
}
