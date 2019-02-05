using System;

public class Product
{
    private string name;
    private decimal price;

    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public decimal Price
    {
        get { return price; }

        private set
        {
            if (value < 0)
                throw new ArgumentException("Money cannot be negative");

            price = value;
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