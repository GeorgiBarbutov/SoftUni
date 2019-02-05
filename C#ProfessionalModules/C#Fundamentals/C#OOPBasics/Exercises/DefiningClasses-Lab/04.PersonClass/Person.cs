using System.Collections.Generic;

public class Person
{
    private string name;
    private int age;
    private List<BankAccount> accounts;

    public Person(string name, int age):this(name, age, new List<BankAccount>())
    {}

    public Person(string name, int age, List<BankAccount> accounts)
    {
        this.name = name;
        this.age = age;
        this.accounts = accounts;
    }

    public decimal GetBalance()
    {
        decimal sum = 0;
        this.accounts.ForEach(x => sum += x.Balance);

        return sum;
    }
}

