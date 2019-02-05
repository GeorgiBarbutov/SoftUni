using System;

class Program
{
    static void Main(string[] args)
    {
        RandomList randomList = new RandomList
        {
            "a",
            "b",
            "c",
            "d"
        };

        Console.WriteLine(randomList.RandomString());
    }
}

