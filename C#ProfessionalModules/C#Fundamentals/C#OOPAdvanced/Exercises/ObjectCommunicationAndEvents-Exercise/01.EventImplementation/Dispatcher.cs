using System;

public delegate void NameChangeEventHandler(object sender, INameChangeEventArgs eventArgs);

public class Dispatcher : IDispatcher
{
    public event NameChangeEventHandler NameChange;
    private string name;

    protected void OnNameChange(INameChangeEventArgs args)
    {
        NameChange("", args);
    }

    public string Name
    {
        get { return name; }
        set
        {
            OnNameChange(new NameChangeEventArgs(value));
            name = value;
        }
    }

}

