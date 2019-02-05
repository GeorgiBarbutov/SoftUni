using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _08.Full_Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Path: ");
            string path = Console.ReadLine();

            Dictionary<string, Dictionary<string, double>> fileInformation = new Dictionary<string, Dictionary<string, double>>();

            List<string> directoryPaths = new List<string>();
            GetDirectories(1, path, directoryPaths);
            directoryPaths.Add(path);

            int repeteCount = 0;
            GetAllFiles(fileInformation, directoryPaths, repeteCount);

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

        private static void GetAllFiles(Dictionary<string, Dictionary<string, double>> fileInformation, List<string> directoryPaths, int repeteCount)
        {
            foreach (var dirPath in directoryPaths)
            {
                try
                {
                    string[] files = Directory.GetFiles(dirPath);

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
                catch (Exception)
                {
                    continue;
                    throw;
                }
            }
        }

        static void GetDirectories(int directoryCount, string path, List<string> directoryPaths)
        {
            try
            {
                var directories = Directory.GetDirectories(path);

                directoryCount = directories.Length;

                if (directoryCount == 0)
                {
                    return;
                }

                foreach (var directory in directories)
                {
                    GetDirectories(0, directory, directoryPaths);

                    directoryPaths.Add(directory);
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
