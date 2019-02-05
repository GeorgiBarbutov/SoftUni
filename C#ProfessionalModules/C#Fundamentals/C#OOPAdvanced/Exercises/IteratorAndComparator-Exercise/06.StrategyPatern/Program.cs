using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        SortedSet<Person> lengthSet = new SortedSet<Person>(new LengthComparer());
        SortedSet<Person> ageSet = new SortedSet<Person>(new AgeComparer());

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] personInput = Console.ReadLine().Split(' ');

            Person person = new Person(personInput[0], int.Parse(personInput[1]));

            lengthSet.Add(person);
            ageSet.Add(person);
        }

        foreach (var person in lengthSet)
        {
            Console.WriteLine(person.Name + " " + person.Age);
        }
        foreach (var person in ageSet)
        {
            Console.WriteLine(person.Name + " " + person.Age);
        }
    }
}

