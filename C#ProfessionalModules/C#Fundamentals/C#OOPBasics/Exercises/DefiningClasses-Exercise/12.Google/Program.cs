using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();

        AddPeopleToList(people);
        PrintPerson(people);
    }

    private static void PrintPerson(List<Person> people)
    {
        string personName = Console.ReadLine();

        Person person = people.FirstOrDefault(x => x.name == personName);

        person.Print();
    }

    private static void AddPeopleToList(List<Person> people)
    {
        string[] personInfo;
        while ((personInfo = Console.ReadLine().Split(' '))[0] != "End")
        {
            string personName = personInfo[0];

            Person person = people.FirstOrDefault(x => x.name == personName);

            if (people.Contains(person))
            {
                EditExistingPerson(personInfo, people, person);
            }
            else
                CreateNewPerson(personInfo, people, personName);
        }
    }

    private static void EditExistingPerson(string[] personInfo, List<Person> people, Person person)
    {
        if (personInfo[1] == "company")
        {
            Person.Company company = new Person.Company(personInfo[2], personInfo[3], double.Parse(personInfo[4]));

            people[people.IndexOf(person)].company = company;
        }
        if (personInfo[1] == "pokemon")
        {
            Person.Pokemon pokemon = new Person.Pokemon(personInfo[2], personInfo[3]);

            people[people.IndexOf(person)].AddPokemon(pokemon);
        }
        if (personInfo[1] == "parents")
        {
            Person.Parent parent = new Person.Parent(personInfo[2], personInfo[3]);

            people[people.IndexOf(person)].AddParent(parent);
        }
        if (personInfo[1] == "children")
        {
            Person.Child child = new Person.Child(personInfo[2], personInfo[3]);

            people[people.IndexOf(person)].AddChild(child);
        }
        if (personInfo[1] == "car")
        {
            Person.Car car = new Person.Car(personInfo[2], int.Parse(personInfo[3]));

            people[people.IndexOf(person)].car = car;
        }
    }

    private static void CreateNewPerson(string[] personInfo, List<Person> people, string personName)
    {
        if (personInfo[1] == "company")
        {
            Person.Company company = new Person.Company(personInfo[2], personInfo[3], double.Parse(personInfo[4]));

            Person newPerson = new Person(personName, company);

            people.Add(newPerson);
        }
        if (personInfo[1] == "pokemon")
        {
            Person.Pokemon pokemon = new Person.Pokemon(personInfo[2], personInfo[3]);

            Person newPerson = new Person(personName, pokemon);

            people.Add(newPerson);
        }
        if (personInfo[1] == "parents")
        {
            Person.Parent parent = new Person.Parent(personInfo[2], personInfo[3]);

            Person newPerson = new Person(personName, parent);

            people.Add(newPerson);
        }
        if (personInfo[1] == "children")
        {
            Person.Child child = new Person.Child(personInfo[2], personInfo[3]);

            Person newPerson = new Person(personName, child);

            people.Add(newPerson);
        }
        if (personInfo[1] == "car")
        {
            Person.Car car = new Person.Car(personInfo[2], int.Parse(personInfo[3]));

            Person newPerson = new Person(personName, car);

            people.Add(newPerson);
        }
    }
}

