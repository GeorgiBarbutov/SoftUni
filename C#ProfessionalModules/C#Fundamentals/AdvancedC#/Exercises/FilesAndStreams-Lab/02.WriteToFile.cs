using System.IO;

namespace _01.Read_File
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"..\..\Program.cs");
            StreamWriter writer = new StreamWriter("reversedText.txt");

            using (reader)
            {
                using (writer)
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        for (int i = line.Length - 1; i >= 0; i--)
                        {
                            writer.Write(line[i]);
                        }
                        writer.WriteLine();
                    }
                }
            }
        }
    }
}
