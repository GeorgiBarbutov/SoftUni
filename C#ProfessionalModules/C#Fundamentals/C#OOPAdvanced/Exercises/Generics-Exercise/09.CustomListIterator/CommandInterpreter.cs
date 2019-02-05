using System;

public class CommandInterpreter
{
    private CustomList<string> customList;

    public CommandInterpreter()
    {
        this.customList = new CustomList<string>();
    }

    public bool InterpreteCommand(string command)
    {
        bool IsNOTEND = true;

        string[] commandParams = command.Split(' ');

        if(commandParams[0] == "Add")
        {
            customList.Add(commandParams[1]);
        }
        else if(commandParams[0] == "Remove")
        {
            customList.Remove(int.Parse(commandParams[1]));
        }
        else if (commandParams[0] == "Contains")
        {
            Console.WriteLine(customList.Contains(commandParams[1]));
        }
        else if (commandParams[0] == "Swap")
        {
            customList.Swap(int.Parse(commandParams[1]), int.Parse(commandParams[2]));
        }
        else if (commandParams[0] == "Greater")
        {
            Console.WriteLine(customList.CountGreaterThan(commandParams[1]));
        }
        else if (commandParams[0] == "Max")
        {
            Console.WriteLine(customList.Max());
        }
        else if (commandParams[0] == "Min")
        {
            Console.WriteLine(customList.Min());
        }
        else if (commandParams[0] == "Print")
        {
            foreach (var item in customList)
            {
                Console.WriteLine(item);
            }
        }
        else if (commandParams[0] == "Sort")
        {
            customList.Sort();
        }
        else if (commandParams[0] == "END")
        {
            return false;
        }

        return IsNOTEND;
    }
}

