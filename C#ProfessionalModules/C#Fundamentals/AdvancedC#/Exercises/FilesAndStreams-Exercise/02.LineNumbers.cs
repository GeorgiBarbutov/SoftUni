using System.IO;

namespace _02.Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("../../../Resorces/text.txt");
            StreamWriter writer = new StreamWriter("output.txt");

            using (reader)
            {
                using (writer)
                {
                    int lineCount = 1;

                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.Write($"Line{lineCount}: {line}");
                        writer.WriteLine();

                        lineCount++;
                    }
                }
            }
        }
    }
}
