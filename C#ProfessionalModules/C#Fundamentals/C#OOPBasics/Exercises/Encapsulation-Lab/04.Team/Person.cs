using System;

public class Person
{
    private const decimal MIN_SALARY = 460;
    private const int MIN_LENGTH = 3;
    private const int MIN_AGE = 0;

    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public decimal Salary
    {
        get { return salary; }

        private set
        {
            if (value < MIN_SALARY)
                throw new ArgumentException("Salary cannot be less than 460 leva!");

            salary = value;
        }
    }

    public string FirstName
    {
        get { return firstName; }

        private set
        {
            if (value?.Length < MIN_LENGTH)
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");

            firstName = value;
        }
    }

    public string LastName
    {
        get { return lastName; }

        private set
        {
            if (value?.Length < MIN_LENGTH)
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");

            lastName = value;
        }
    }

    public int Age
    {
        get { return age; }
        private set
        {
            if (value <= MIN_AGE)
                throw new ArgumentException("Age cannot be zero or a negative integer!");

            age = value;
        }
    }

    public Person(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public Person(string firstName, string lastName, int age, decimal salary) : this(firstName, lastName, age)
    {
        Salary = salary;
    }

    public void IncreaseSalary(decimal percentage)
    {
        if (Age < 30)
        {
            Salary += Salary * percentage / 200;
        }
        else
            Salary += Salary * percentage / 100;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName} receives {Salary:f2} leva.";
    }
}

