using System;
using System.Collections.Generic;

public class Animals
{
    public static void Main(string[] args)
    {
        var animals = new List<Animal>();

        string input;
        while ((input = Console.ReadLine().ToLower()) != "beast!")
        {
            try
            {
                var animalType = input;
                var animalInfo = Console.ReadLine()
                    .Split(new []{" "},StringSplitOptions.RemoveEmptyEntries);

                GetTypeAndAddAnimal(animals, animalType, animalInfo);
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
            }
        }
        Console.WriteLine(string.Join(Environment.NewLine, animals));
    }

    private static void GetTypeAndAddAnimal(List<Animal> animals, string animalType, string[] animalInfo)
    {
        if (animalType.ToLower() == "dog")
        {
            animals.Add(new Dog(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]));
        }
        else if (animalType.ToLower() == "frog")
        {
            animals.Add(new Frog(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]));
        }
        else if (animalType.ToLower() == "cat")
        {
            animals.Add(new Cat(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]));
        }
        else if (animalType.ToLower() == "kitten")
        {
            animals.Add(new Kitten(animalInfo[0], int.Parse(animalInfo[1])));
        }
        else if (animalType.ToLower() == "tomcat")
        {
            animals.Add(new Tomcat(animalInfo[0], int.Parse(animalInfo[1])));
        }
        else
        {
            throw new ArgumentException("Invalid input!");
        }
    }
}