using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Stack<string> stack = new Stack<string>();

        string[] input;

        while((input = Console.ReadLine().Split(", "))[0] != "END")
        {
            string command = input[0].Split(' ')[0];
            
            if (command == "Push")
            {
                if (input[0].Split(' ')[1] != null)
                {
                    string[] parameters = new string[input.Length];
                    parameters[0] = input[0].Split(' ')[1];

                    for (int i = 1; i < input.Length; i++)
                    {
                        parameters[i] = input[i];
                    }

                    stack.Push(parameters);
                }                
            }
            else if (command == "Pop")
            {
                try
                {
                    stack.Pop();
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }              
            }
        }

        foreach (var element in stack)
        {
            Console.WriteLine(element);
        }
        foreach (var element in stack)
        {
            Console.WriteLine(element);
        }
    }
}

