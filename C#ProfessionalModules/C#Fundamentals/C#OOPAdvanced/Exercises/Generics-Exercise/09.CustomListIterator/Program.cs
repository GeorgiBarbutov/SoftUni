using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        CommandInterpreter commandInterpreter = new CommandInterpreter();

        bool isNOTEnd = true;

        while(isNOTEnd)
        {
            string command = Console.ReadLine();

            isNOTEnd = commandInterpreter.InterpreteCommand(command);
        }
    }
}

