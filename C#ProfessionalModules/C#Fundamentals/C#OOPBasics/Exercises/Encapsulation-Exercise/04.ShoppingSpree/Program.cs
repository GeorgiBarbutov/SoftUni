using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            AddPeople(people);
            AddProducts(products);
            Shoping(people, products);
            Print(people);
        }
        catch (ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
        }
    }

    private static void Print(List<Person> people)
    {
        foreach (var person in people)
        {
            person.Print();
        }
    }

    private static void Shoping(List<Person> people, List<Product> products)
    {
        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            string personName = input.Split(' ')[0];
            string productName = input.Split(' ')[1];

            Person person = people.FirstOrDefault(x => x.Name == personName);
            Product product = products.FirstOrDefault(x => x.Name == productName);

            if(person != null && product != null)
                person.Buy(product);
        }
    }

    private static void AddProducts(List<Product> products)
    {
        string[] productInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

        foreach (var product in productInput)
        {
            string name = product.Split('=')[0].Trim();
            int price = int.Parse(product.Split('=')[1]);

            Product newProduct = new Product(name, price);

            products.Add(newProduct);
        }
    }

    private static void AddPeople(List<Person> people)
    {
        string[] peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

        foreach (var person in peopleInput)
        {
            string name = person.Split('=')[0].Trim();
            int money = int.Parse(person.Split('=')[1]);

            Person newPerson = new Person(name, money);

            people.Add(newPerson);
        }
    }
}

