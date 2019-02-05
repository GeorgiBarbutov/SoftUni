using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        DraftManager draftManager = new DraftManager();

        while(true)
        {
            List<string> commandArguments = Console.ReadLine().Split(' ').ToList();

            string command = commandArguments[0];

            if(command == "RegisterHarvester")
            {
                Console.WriteLine(draftManager.RegisterHarvester(commandArguments.Skip(1).ToList()));
            }
            else if(command == "RegisterProvider")
            {
                Console.WriteLine(draftManager.RegisterProvider(commandArguments.Skip(1).ToList()));                
            }
            else if (command == "Day")
            {
                Console.WriteLine(draftManager.Day());
            }
            else if (command == "Mode")
            {
                Console.WriteLine(draftManager.Mode(commandArguments.Skip(1).ToList()));
            }
            else if (command == "Check")
            {
                Console.WriteLine(draftManager.Check(commandArguments.Skip(1).ToList()));
            }
            else if (command == "Shutdown")
            {
                Console.WriteLine(draftManager.ShutDown());
                

                break;
            }
        }
    }
}

