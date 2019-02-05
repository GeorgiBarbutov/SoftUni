using System;
using System.Collections.Generic;
using System.Linq;

namespace Hit_List
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetInfoIndex = int.Parse(Console.ReadLine());

            string input;

            Dictionary<string, Dictionary<string, string>> allInfo = new Dictionary<string, Dictionary<string, string>>();

            while ((input = Console.ReadLine()) != "end transmissions")
            {
                int indexToBreakAt = input.IndexOf('=');

                string name = input.Substring(0, indexToBreakAt);
                Dictionary<string, string> info = new Dictionary<string, string>();

                string key = null;
                string value = null;

                for (int i = 0; i < input.Length; i++)
                {                   
                    if (input[i] == ':')
                    {
                        key = input.Substring(indexToBreakAt + 1, i - indexToBreakAt - 1);

                        indexToBreakAt = i;
                    }
                    if (input[i] == ';' || i == input.Length - 1)
                    {
                        if(i == input.Length - 1)
                        {
                            value = input.Substring(indexToBreakAt + 1, i - indexToBreakAt);
                        }
                        else
                        {
                            value = input.Substring(indexToBreakAt + 1, i - indexToBreakAt - 1);
                        }

                        

                        indexToBreakAt = i;

                        if (allInfo.ContainsKey(name))
                        {
                            if(allInfo[name].ContainsKey(key))
                            {
                                allInfo[name][key] = value;
                            }
                            else
                            {
                                allInfo[name].Add(key, value);
                            }
                        }
                        else
                        {
                            allInfo.Add(name, new Dictionary<string, string>());
                            allInfo[name].Add(key, value);
                        }
                    }
                }
            }

            string nameToKill = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];

            Dictionary<string, string> infoOnTarget = allInfo[nameToKill].OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine($"Info on {nameToKill}:");

            int infoIndex = 0;

            foreach (var info in infoOnTarget)
            {
                infoIndex += info.Key.Length + info.Value.Length;
                Console.WriteLine($"---{info.Key}: {info.Value}");
            }

            Console.WriteLine($"Info index: {infoIndex}");

            if(infoIndex >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfoIndex - infoIndex} more info.");
            }
        }
    }
}
