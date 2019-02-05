using System;

class Program
{
    static void Main(string[] args)
    {
        string name = Console.ReadLine();

        ICar car = new Ferrari(name);

        Console.WriteLine(car);
    }
}

