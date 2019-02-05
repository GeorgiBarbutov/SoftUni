using System;
using System.Collections.ObjectModel;

class Program
{
    static void Main(string[] args)
    {
        Collection<IAnimal> animals = new Collection<IAnimal>();

        AddAnimals(animals);
        PrintAnimals(animals);
    }

    private static void PrintAnimals(Collection<IAnimal> animals)
    {
        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }

    private static void AddAnimals(Collection<IAnimal> animals)
    {
        string[] animalParams;

        while ((animalParams = Console.ReadLine().Split(' '))[0] != "End")
        {
            Animal animal = AddAnimal(animals, animalParams);
            Food food = GetFood();

            animal.Eat(food);
        }
    }

    private static Food GetFood()
    {
        Food food = null;

        string[] foodParams = Console.ReadLine().Split(' ');

        if (foodParams[0] == "Vegetable")
        {
            food = new Vegetable(int.Parse(foodParams[1]));
        }
        else if (foodParams[0] == "Fruit")
        {
            food = new Fruit(int.Parse(foodParams[1]));
        }
        else if (foodParams[0] == "Meat")
        {
            food = new Meat(int.Parse(foodParams[1]));
        }
        else if (foodParams[0] == "Seeds")
        {
            food = new Seeds(int.Parse(foodParams[1]));
        }

        return food;
    }

    private static Animal AddAnimal(Collection<IAnimal> animals, string[] animalParams)
    {
        Animal animal = null;

        if (animalParams[0] == "Owl")
        {
            animal = AddOwl(animals, animalParams);
        }
        else if (animalParams[0] == "Hen")
        {
            animal = AddHen(animals, animalParams);
        }
        else if (animalParams[0] == "Mouse")
        {
            animal = AddMouse(animals, animalParams);
        }
        else if (animalParams[0] == "Dog")
        {
            animal = AddDog(animals, animalParams);
        }
        else if (animalParams[0] == "Cat")
        {
            animal = AddCat(animals, animalParams);
        }
        else if (animalParams[0] == "Tiger")
        {
            animal = AddTiger(animals, animalParams);
        }

        return animal;
    }

    private static Animal AddTiger(Collection<IAnimal> animals, string[] animalParams)
    {
        Tiger tiger = new Tiger(animalParams[1], double.Parse(animalParams[2]), animalParams[3], animalParams[4]);
        animals.Add(tiger);

        return tiger;
    }

    private static Animal AddCat(Collection<IAnimal> animals, string[] animalParams)
    {
        Cat cat = new Cat(animalParams[1], double.Parse(animalParams[2]), animalParams[3], animalParams[4]);
        animals.Add(cat);

        return cat;
    }

    private static Animal AddDog(Collection<IAnimal> animals, string[] animalParams)
    {
        Dog dog = new Dog(animalParams[1], double.Parse(animalParams[2]), animalParams[3]);
        animals.Add(dog);

        return dog;
    }

    private static Animal AddMouse(Collection<IAnimal> animals, string[] animalParams)
    {
        Mouse mouse = new Mouse(animalParams[1], double.Parse(animalParams[2]), animalParams[3]);
        animals.Add(mouse);

        return mouse;
    }

    private static Animal AddOwl(Collection<IAnimal> animals, string[] animalParams)
    {
        Owl owl = new Owl(animalParams[1], double.Parse(animalParams[2]), double.Parse(animalParams[3]));
        animals.Add(owl);

        return owl;
    }

    private static Animal AddHen(Collection<IAnimal> animals, string[] animalParams)
    {
        Hen hen = new Hen(animalParams[1], double.Parse(animalParams[2]), double.Parse(animalParams[3]));
        animals.Add(hen);

        return hen;
    }
}

