using System;
using System.Collections.Generic;

public class Engine : IEngine
{
    private IList<IWeapon> weapons;

    public Engine()
    {
        this.weapons = new List<IWeapon>();
    }

    public void Run()
    {
        string[] commandInput;

        while((commandInput = Console.ReadLine().Split(';'))[0] != "END")
        {
            ICommandParser commandParser = new CommandParser(commandInput, weapons);
            IExecutable command = commandParser.CreateCommand();

            command.Execute();
        }       
    }
}

