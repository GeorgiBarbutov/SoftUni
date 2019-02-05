using System;
using System.Collections.Generic;

public class Person
{
    public string name { get; set; }
    public Company company { get; set; }
    public Car car { get; set; }
    public List<Parent> parents { get; private set; }
    public List<Child> children { get; private set; }
    public List<Pokemon> pokemon { get; private set; }

    public Person(string name, Company company, Car car, Parent parent, Child child, Pokemon pokemon)
    {
        this.name = name;

        if(company != null)
            this.company = company;
        if (car != null)
            this.car = car;

        parents = new List<Parent>();
        children = new List<Child>();
        this.pokemon = new List<Pokemon>();

        if (parent != null)
            parents.Add(parent);
        if (child != null)
            children.Add(child);
        if (pokemon != null)
            this.pokemon.Add(pokemon);
    }

    public Person(string name, Company company) : this(name, company, null, null, null, null)
    { }
    public Person(string name, Pokemon pokemon) : this(name, null, null, null, null, pokemon)
    { }
    public Person(string name, Parent parent) : this(name, null, null, parent, null, null)
    { }
    public Person(string name, Child child) : this(name, null, null, null, child, null)
    { }
    public Person(string name, Car car) : this(name, null, car, null, null, null)
    { }

    public void AddParent(Parent parent)
    {
        parents.Add(parent);
    }

    public void AddChild(Child child)
    {
        children.Add(child);
    }

    public void AddPokemon(Pokemon pokemon)
    {
        this.pokemon.Add(pokemon);
    }

    public void Print()
    {
        Console.WriteLine(name);

        Console.WriteLine("Company:");
        if (company != null) 
            Console.WriteLine(company.ToString());

        Console.WriteLine("Car:");
        if (car != null)  
            Console.WriteLine(car.ToString());

        Console.WriteLine("Pokemon:");
        foreach (var p in pokemon)
        {
            Console.WriteLine(p.ToString());
        }

        Console.WriteLine("Parents:");
        foreach (var parent in parents)
        {
            Console.WriteLine(parent.ToString());
        }

        Console.WriteLine("Children:");
        foreach (var child in children)
        {
            Console.WriteLine(child.ToString());
        }
    }

    public class Company
    {
        public string Name { get; private set; }
        public string Departament { get; private set; }
        public double Salary { get; private set; }

        public Company(string name, string departament, double salary)
        {
            Name = name;
            Departament = departament;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"{Name} {Departament} {Salary:f2}";
        }
    }

    public class Car
    {
        public string Model { get; private set; }
        public int Speed { get; private set; }

        public Car(string model, int speed)
        {
            Model = model;
            Speed = speed;
        }

        public override string ToString()
        {
            return $"{Model} {Speed}";
        }
    }

    public class Parent
    {
        public string Name { get; private set; }
        public string Birthday { get; private set; }

        public Parent(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
        }

        public override string ToString()
        {
            return $"{Name} {Birthday}";
        }
    }

    public class Child
    {
        public string Name { get; private set; }
        public string Birthday { get; private set; }

        public Child(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
        }

        public override string ToString()
        {
            return $"{Name} {Birthday}";
        }
    }

    public class Pokemon
    {
        public string Name { get; private set; }
        public string Type { get; private set; }

        public Pokemon(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Name} {Type}";
        }
    }
}



