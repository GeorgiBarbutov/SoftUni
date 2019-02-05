using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string[] commandParameters;

            while ((commandParameters = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray()).Length != 1)
            {
                string command = commandParameters[0];
                string criteria = commandParameters[1];
                string criteriaArgument = commandParameters[2];

                Func<string, bool> filter = CreateFilter(criteria, criteriaArgument);
                Func<List<string>, string, List<string>> modifier = CreateModifier(command);

                for (int i = 0; i < names.Count; i++)
                {
                    if(filter(names[i]))
                    {
                        names = modifier(names, names[i]);

                        if(command == "Remove")
                        {
                            i--;
                        }
                        if(command == "Double")
                        {
                            i++;
                        }
                    }

                }
            }

            if(names.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine(String.Join(", ", names) + " are going to the party!");
            }
        }

        private static Func<List<string>, string,  List<string>> CreateModifier(string command)
        {
            if(command == "Remove")
            {
                return (names, name) =>
                {
                    for (int i = 0; i < names.Count; i++)
                    {
                        if(names[i] == name)
                        {
                            names.RemoveAt(i);
                        }
                    }

                    return names;
                };
            }
            else
            {
                return (names, name) =>
                {
                    for (int i = 0; i < names.Count; i++)
                    {
                        if(names[i] == name)
                        {
                            names.Insert(i + 1, name);
                            i ++;
                        }
                    }

                    return names;
                };
            }
        }

        private static Func<string, bool> CreateFilter(string criteria, string criteriaArgument)
        {
            if (criteria == "StartsWith")
            {
                return x => x.Substring(0, criteriaArgument.Length) == criteriaArgument;
            }
            else if (criteria == "EndsWith")
            {
                return x => x.Substring(x.Length - criteriaArgument.Length, criteriaArgument.Length) == criteriaArgument;
            }
            else
            {
                return x => x.Length == int.Parse(criteriaArgument); 
            }
        }
    }
}
