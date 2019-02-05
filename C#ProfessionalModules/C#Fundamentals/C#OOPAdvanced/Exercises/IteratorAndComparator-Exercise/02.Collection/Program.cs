using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] initialCommand = Console.ReadLine().Split(' ');

        ListyIterator<string> listyIterator = new ListyIterator<string>(initialCommand.Skip(1).ToArray());

        string command;

        while ((command = Console.ReadLine()) != "END")
        {
            if(command == "Move")
            {
                Console.WriteLine(listyIterator.Move());
            }
            else if (command == "HasNext")
            {
                Console.WriteLine(listyIterator.HasNext());
            }
            else if (command == "Print")
            {
                try
                {
                    listyIterator.Print();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (command == "PrintAll")
            {
                foreach (var element in listyIterator)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

