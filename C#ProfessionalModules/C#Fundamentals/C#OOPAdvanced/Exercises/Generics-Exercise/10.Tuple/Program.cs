using System;

public class Program
{
    static void Main(string[] args)
    {
        string[] input1 = Console.ReadLine().Split(' ');
        string[] input2 = Console.ReadLine().Split(' ');
        string[] input3 = Console.ReadLine().Split(' ');

        MyTuple<string, string> tuple1 = new MyTuple<string, string>(input1[0] + " " + input1[1], input1[2]);
        MyTuple<string, int> tuple2 = new MyTuple<string, int>(input2[0], int.Parse(input2[1]));
        MyTuple<int, double> tuple3 = new MyTuple<int, double>(int.Parse(input3[0]), double.Parse(input3[1]));

        Console.WriteLine(tuple1);
        Console.WriteLine(tuple2);
        Console.WriteLine(tuple3);
    }
}

