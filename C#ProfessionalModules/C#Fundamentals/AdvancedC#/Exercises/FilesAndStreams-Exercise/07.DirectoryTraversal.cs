using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07.Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Path: ");
            string path = Console.ReadLine();

            Dictionary<string, Dictionary<string, double>> fileInformation = new Dictionary<string, Dictionary<string, double>>();

            int repeteCount = 0;
            GetAllFiles(fileInformation, path, repeteCount);

            WriteToReport(fileInformation);
        }

        private static void WriteToReport(Dictionary<string, Dictionary<string, double>> fileInformation)
        {
            Dictionary<string, Dictionary<string, double>> orderedFilesInformation = fileInformation.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt";


            using (StreamWriter writer = new StreamWriter(desktopPath))
            {
                foreach (var extension in orderedFilesInformation)
                {
                    writer.WriteLine(extension.Key);

                    foreach (var file in extension.Value)
                    {
                        writer.WriteLine($"--{file.Key} - {file.Value}kb");
                    }
                }
            }
        }
        private static void GetAllFiles(Dictionary<string, Dictionary<string, double>> fileInformation, string path, int repeteCount)
        {
            string[] files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                FileInfo Info = new FileInfo(file);

                string extension = Info.Extension;
                string name = Info.Name;
                double length = Info.Length / 1024.0;

                if (fileInformation.ContainsKey(extension))
                {
                    if (fileInformation[extension].ContainsKey(name))
                    {
                        name += $"repeated {repeteCount + 1}";
                        repeteCount++;
                    }
                    fileInformation[extension].Add(name, length);
                }
                else
                {
                    fileInformation.Add(extension, new Dictionary<string, double>());
                    fileInformation[extension].Add(name, length);
                }
            }
        }
    }
}
