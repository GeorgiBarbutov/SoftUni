using System;
using System.Collections.Generic;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> bagOfProducts;

    public Person(string name, int money)
    {
        Name = name;
        Money = money;
        BagOfProducts = new List<Product>();
    }

    public void Buy(Product product)
    {
        if(Money >= product.Price)
        {
            BagOfProducts.Add(product);

            Money -= product.Price;

            Console.WriteLine($"{Name} bought {product.Name}");
        }
        else
        {
            Console.WriteLine($"{Name} can't afford {product.Name}");
        }
    }

    public void Print()
    {
        if(BagOfProducts.Count == 0)
        {
            Console.WriteLine($"{Name} - Nothing bought");
        }
        else
        {
            Console.Write($"{Name} - ");

            for (int i = 0; i < BagOfProducts.Count; i++)
            {
                if(i == 0)
                {
                    Console.Write(BagOfProducts[i].Name);
                }
                else
                {
                    Console.Write(", " + BagOfProducts[i].Name);
                }
            }

            Console.WriteLine();
        }
    }

    private List<Product> BagOfProducts
    {
        get { return bagOfProducts; }
        set { bagOfProducts = value; }
    }

    private decimal Money
    {
        get { return money; }

        set
        {
            if (value < 0)
                throw new ArgumentException("Money cannot be negative");

            money = value;
        }
    }


    public string Name
    {
        get { return name; }

        private set
        {
            if (value == string.Empty || value == null)
                throw new ArgumentException("Name cannot be empty");

            name = value;
        }
    }

}