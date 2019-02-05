using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        IList<Person> people = new List<Person>();

        AddPeople(people);
        int matches = FindMatches(people);
        Print(people, matches);
    }

    private static void Print(IList<Person> people, int matches)
    {
        if (matches <= 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            int allPeople = people.Count;
            int noMatches = allPeople - matches;

            Console.WriteLine(matches + " " + noMatches + " " + allPeople);
        }
    }

    private static int FindMatches(IList<Person> people)
    {
        int n = int.Parse(Console.ReadLine());
        Person personToCompareTo = people[n - 1];
        int matches = 0;

        foreach (var person in people)
        {
            if (person.CompareTo(personToCompareTo) == 0)
            {
                matches++;
            }
        }

        return matches;
    }

    private static void AddPeople(IList<Person> people)
    {
        string[] input;

        while ((input = Console.ReadLine().Split(' '))[0] != "END")
        {
            Person person = new Person(input[0], int.Parse(input[1]), input[2]);

            people.Add(person);
        }
    }
}

