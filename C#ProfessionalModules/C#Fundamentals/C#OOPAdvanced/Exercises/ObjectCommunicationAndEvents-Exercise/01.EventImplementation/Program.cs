using System;

public class Program
{
    static void Main(string[] args)
    {
        IHandler handler = new Handler();
        IDispatcher dispatcher = new Dispatcher();
        dispatcher.NameChange += handler.OnDispatcherNameChange;

        string name;

        while((name = Console.ReadLine()) != "End")
        {
            dispatcher.Name = name;
        }
    }
}

