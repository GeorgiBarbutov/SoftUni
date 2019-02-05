using System;
using System.Collections.Generic;
using System.IO;

namespace _05.Slicing_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string destinationDirectory = "../../";
            string sourceFile = "../../../Resorces/sliceMe.mp4";

            int parts = 5;

            List<string> files = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                files.Add($"../../Part - {i}.mp4");
            }

            Slice(sourceFile, destinationDirectory, parts);

            Assemble(files, destinationDirectory);
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                long partLenght = (long)Math.Ceiling((double)reader.Length / parts);
                
                for (int i = 0; i < parts; i++)
                {
                    long currentPartLenght = 0;

                    if (destinationDirectory == string.Empty)
                    {
                        destinationDirectory = "./";
                    }

                    string extension = sourceFile.Substring(sourceFile.LastIndexOf(".") + 1);

                    string path = destinationDirectory + $"Part - {i}.{extension}";

                    using (FileStream writer = new FileStream(path, FileMode.Create))
                    {
                        byte[] buffer = new byte[4096];
                      
                        while (reader.Read(buffer, 0, 4096) == 4096)
                        {
                            writer.Write(buffer, 0, 4096);

                            currentPartLenght += 4096;

                            if(currentPartLenght >= partLenght)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        static void Assemble(List<string> files, string destinationDirectory)
        {
            if(destinationDirectory == string.Empty)
            {
                destinationDirectory = "./";
            }

            string path = destinationDirectory + $"assembled.{files[0].Substring(files[0].LastIndexOf('.') + 1)}";

            using (FileStream writer = new FileStream(path, FileMode.Create))
            {
                for (int i = 0; i < files.Count; i++)
                {
                    using (FileStream reader = new FileStream(files[i], FileMode.Open))
                    {
                        byte[] buffer = new byte[4096];

                        while (reader.Read(buffer, 0, 4096) == 4096)
                        {
                            writer.Write(buffer, 0, 4096);
                        }
                    }
                }
            }
        }

    }
}
