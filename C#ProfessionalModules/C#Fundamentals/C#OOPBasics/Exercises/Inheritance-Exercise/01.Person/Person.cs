using System;

public class Person
{
    private string name;
    private int age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;  
    }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}";
    }

    protected virtual int Age
    {
        get { return age; }

        set
        {
            if (value < 0)
                throw new ArgumentException("Age must be positive!");

            age = value;
        }
    }

    protected virtual string Name
    {
        get { return name; }

        set
        {
            if (value.Length < 3)
                throw new ArgumentException("Name's length should not be less than 3 symbols!");

            name = value;
        }
    }
}

