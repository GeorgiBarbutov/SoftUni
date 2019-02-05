using System;

public class NameChangeEventArgs : EventArgs, INameChangeEventArgs
{
    private string name;

    public NameChangeEventArgs(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

}