using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Human> people = new List<Human>();

        AddPeople(people);
        
        int foodBought = 0;
        foodBought = BuyFood(people, foodBought);

        Console.WriteLine(foodBought);
    }

    private static int BuyFood(List<Human> people, int foodBought)
    {
        string name;

        while ((name = Console.ReadLine()) != "End")
        {
            foreach (var person in people)
            {
                if (person.Name == name)
                {
                    foodBought += person.BuyFood();
                }
            }
        }

        return foodBought;
    }

    private static void AddPeople(List<Human> people)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] peopleParam = Console.ReadLine().Split(' ');

            if (peopleParam.Length == 4)
            {
                AddCitizen(people, peopleParam);
            }
            else
            {
                AddRebel(people, peopleParam);
            }
        }
    }

    private static void AddRebel(List<Human> people, string[] peopleParam)
    {
        string name = peopleParam[0];
        int age = int.Parse(peopleParam[1]);
        string group = peopleParam[2];

        people.Add(new Rebel(name, age, group));
    }

    private static void AddCitizen(List<Human> people, string[] peopleParam)
    {
        string name = peopleParam[0];
        int age = int.Parse(peopleParam[1]);
        string id = peopleParam[2];
        string birthdate = peopleParam[3];

        people.Add(new Citizen(name, age, id, birthdate));
    }
}

