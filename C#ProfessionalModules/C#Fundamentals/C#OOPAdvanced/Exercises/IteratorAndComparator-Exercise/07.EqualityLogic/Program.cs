using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        SortedSet<Person> sortedSet = new SortedSet<Person>(new EqualityComparer());
        HashSet<Person> hashedSet = new HashSet<Person>(new EqualityComparer());

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] personInput = Console.ReadLine().Split(' ');

            Person person = new Person(personInput[0], int.Parse(personInput[1]));

            sortedSet.Add(person);
            hashedSet.Add(person);
        }

        Console.WriteLine(sortedSet.Count);
        Console.WriteLine(hashedSet.Count);
    }
}

