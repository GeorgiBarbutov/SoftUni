using System.Collections.Generic;

public class CommandParser : ICommandParser
{
    private string[] commandInput;
    private IList<IWeapon> weapons;

    public CommandParser(string[] commandInput, IList<IWeapon> weapons)
    {
        this.commandInput = commandInput;
        this.weapons = weapons;
    }

    public IExecutable CreateCommand()
    {
        string commandType = this.commandInput[0] + "Command";
        IExecutable command = null;

        if(commandType == "CreateCommand")
        {
            command = new CreateCommand(commandInput[1], commandInput[2], this.weapons);
        }
        else if (commandType == "RemoveCommand")
        {
            command = new RemoveCommand(commandInput[1], int.Parse(commandInput[2]), this.weapons);
        }
        else if (commandType == "AddCommand")
        {
            command = new AddCommand(commandInput[1], int.Parse(commandInput[2]), commandInput[3], this.weapons);
        }
        else if (commandType == "PrintCommand")
        {
            command = new PrintCommand(commandInput[1], this.weapons);
        }

        return command;
    }
}