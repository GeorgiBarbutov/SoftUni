using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Person> peopleList = new List<Person>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] personInput = Console.ReadLine().Split(' ');

            string personName = personInput[0];
            int personAge = int.Parse(personInput[1]);

            if (personAge > 30)
            {
                Person newPerson = new Person(personAge, personName);
                peopleList.Add(newPerson);
            }  
        }

        peopleList = peopleList.OrderBy(x => x.Name).ToList();

        for (int i = 0; i < peopleList.Count; i++)
        {
            Console.WriteLine($"{peopleList[i].Name} - {peopleList[i].Age}");
        }
    }
}

