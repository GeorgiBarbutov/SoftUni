using System;
using System.Collections.Generic;

public class Person
{
    public string Name { get; set; }
    public string Birthday { get; set; }
    public List<Person> Parents { get; set; }
    public List<Person> Children { get; set; }

    private Person()
    {
        Parents = new List<Person>();
        Children = new List<Person>();
    }

    public Person(string nameOrBirthday) : this()
    {
        if(Char.IsDigit(nameOrBirthday[0]))
        {
            Birthday = nameOrBirthday;
        }
        else
        {
            Name = nameOrBirthday;
        }
    }

    public override string ToString()
    {
        return $"{Name} {Birthday}";
    }

    public void Print()
    {
        Console.WriteLine(this.ToString());
        Console.WriteLine("Parents:");

        foreach (var parent in Parents)
        {
            Console.WriteLine(parent.ToString());
        }

        Console.WriteLine("Children:");

        foreach (var child in Children)
        {
            Console.WriteLine(child.ToString());
        }
    }
}

