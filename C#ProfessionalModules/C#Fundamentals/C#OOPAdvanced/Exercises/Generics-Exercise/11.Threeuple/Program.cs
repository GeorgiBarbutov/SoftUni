using System;

public class Program
{
    static void Main(string[] args)
    {
        string[] input1 = Console.ReadLine().Split(' ');
        string[] input2 = Console.ReadLine().Split(' ');
        string[] input3 = Console.ReadLine().Split(' ');

        Treeupe<string, string, string> tuple1 = new Treeupe<string, string, string>(input1[0] + " " + input1[1], input1[2], input1[3]);
        Treeupe<string, int, bool> tuple2;

        if (input2[2] == "drunk")
        {
            tuple2 = new Treeupe<string, int, bool>(input2[0], int.Parse(input2[1]), true);
        }
        else
        {
            tuple2 = new Treeupe<string, int, bool>(input2[0], int.Parse(input2[1]), false);
        }

        Treeupe<string, double, string> tuple3 = new Treeupe<string, double, string>(input3[0], double.Parse(input3[1]), input3[2]);

        Console.WriteLine(tuple1);
        Console.WriteLine(tuple2);
        Console.WriteLine(tuple3);
    }
}

