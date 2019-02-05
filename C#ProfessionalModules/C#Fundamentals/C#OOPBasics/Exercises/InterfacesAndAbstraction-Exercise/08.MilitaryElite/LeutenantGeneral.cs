using System;
using System.Collections.Generic;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    private List<Private> privates;

    public LeutenantGeneral(string id, string firstName, string lastName, double salary)
        : base(id, firstName, lastName, salary)
    {
        this.privates = new List<Private>();
    }

    public void AddPrivate(Private _private)
    {
        privates.Add(_private);
    }

    public override string ToString()
    {
        string result = base.ToString() + Environment.NewLine + "Privates:";

        foreach (var _private in privates)
        {
            result += Environment.NewLine + "  " + _private.ToString();
        }

        return result;
    }
}
