using System;
using System.Collections.Generic;
using System.Linq;

public class StackOfStrings
{
    private List<string> data;

    private List<string> Data
    {
        get { return data; }
        set { data = value; }
    }

    public StackOfStrings()
    {
        Data = new List<string>();
    }

    public void Push(string item)
    {
        Data.Add(item);
    }

    public string Pop()
    {
        if(this.IsEmpty())
        {
            throw new ArgumentException("Stack is empty");
        }

        string lastElement = Data.Last();

        Data.Remove(lastElement);

        return lastElement;
    }

    public string Peek()
    {
        if (this.IsEmpty())
        {
            throw new ArgumentException("Stack is empty");
        }

        string lastElement = Data.Last();

        return lastElement;
    }

    public bool IsEmpty()
    {
        if (Data.Count == 0)
            return true;
        else
            return false;
    }
}

