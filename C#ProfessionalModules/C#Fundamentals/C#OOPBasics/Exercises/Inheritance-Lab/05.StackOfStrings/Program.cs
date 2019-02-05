using System;

class Program
{
    static void Main(string[] args)
    {
        StackOfStrings stack = new StackOfStrings();

        try
        {
            stack.Peek();
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
       
    }
}

