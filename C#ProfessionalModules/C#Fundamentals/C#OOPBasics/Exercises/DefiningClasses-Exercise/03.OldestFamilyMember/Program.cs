using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        Family family = new Family();

        for (int i = 0; i < n; i++)
        {
            string[] personInput = Console.ReadLine().Split(' ');

            string personName = personInput[0];
            int personAge = int.Parse(personInput[1]);

            Person person = new Person(personAge, personName);

            family.AddMember(person);
        }

        Person oldestFamilyMember = family.GetOldestMember();

        Console.WriteLine($"{oldestFamilyMember.Name} {oldestFamilyMember.Age}");
    }
}

