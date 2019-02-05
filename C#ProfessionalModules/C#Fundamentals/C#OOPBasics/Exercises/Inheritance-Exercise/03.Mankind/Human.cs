using System;

public class Human
{
    private string firstName;
    private string secondName;

    public Human(string firstName, string secondName)
    {
        FirstName = firstName;
        SecondName = secondName;
    }

    protected string SecondName
    {
        get { return secondName; }

        set
        {
            if (!Char.IsUpper(value[0]))
                throw new ArgumentException($"Expected upper case letter! Argument: lastName");
            else if (value.Length < 3)
                throw new ArgumentException($"Expected length at least 3 symbols! Argument: lastName");
            else
                secondName = value;
        }
    }

    protected string FirstName
    {
        get { return firstName; }

        set
        {
            if (!Char.IsUpper(value[0]))
                throw new ArgumentException($"Expected upper case letter! Argument: firstName");
            else if (value.Length < 4)
                throw new ArgumentException($"Expected length at least 4 symbols! Argument: firstName");
            else
                firstName = value;
        }
    }

}

