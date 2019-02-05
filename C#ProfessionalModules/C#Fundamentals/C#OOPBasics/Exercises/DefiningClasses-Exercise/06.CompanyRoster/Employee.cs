public class Employee
{
    private string name;
    private double salary;
    private string position;
    private string departament;

    private string email;
    private int age;

    public Employee(string name, double salary, string position, string departament, string email, int age)
    {
        Name = name;
        Salary = salary;
        Position = position;
        Departament = departament;
        Email = email;
        Age = age;
    }

    public void Print()
    {
        System.Console.WriteLine($"{Name} {Salary:f2} {Email} {Age}");
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public string Position
    {
        get { return position; }
        set { position = value; }
    }

    public string Departament
    {
        get { return departament; }
        set { departament = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }
}

