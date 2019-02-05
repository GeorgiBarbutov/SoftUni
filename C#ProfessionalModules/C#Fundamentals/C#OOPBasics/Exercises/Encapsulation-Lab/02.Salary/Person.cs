public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public decimal Salary
    {
        get { return salary; }
        private set { salary = value; }
    }

    public string FirstName
    {
        get { return firstName; }
        private set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        private set { lastName = value; }
    }

    public int Age
    {
        get { return age; }
        private set { age = value; }
    }

    public Person(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public Person(string firstName, string lastName, int age, decimal salary):this(firstName, lastName, age)
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

