using System;

public class Handler : IHandler
{
    public void OnDispatcherNameChange(object sender, INameChangeEventArgs args)
    {
        Console.WriteLine($"Dispatcher's name changed to {args.Name}.");
    }
}

