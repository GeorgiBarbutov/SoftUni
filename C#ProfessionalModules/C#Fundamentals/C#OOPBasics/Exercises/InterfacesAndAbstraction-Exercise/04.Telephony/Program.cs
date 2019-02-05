using System;

class Program
{
    static void Main(string[] args)
    {
        string[] phones = Console.ReadLine().Split(' ');
        string[] sites = Console.ReadLine().Split(' ');

        Smartphone smartphone = new Smartphone(phones, sites);

        smartphone.CallPhones();
        smartphone.BrowseWeb();
    }
}

