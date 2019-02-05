using System;
using System.IO;

namespace _01.Read_File
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader stream = new StreamReader(@"..\..\Program.cs");

            using (stream)
            {
                string line;
                int lineCount = 1;

                while ((line = stream.ReadLine()) != null)
                {
                    //Console.WriteLine($"Line{lineCount}: {line}");
                    lineCount++;
                }
            }
        }
    }
}

