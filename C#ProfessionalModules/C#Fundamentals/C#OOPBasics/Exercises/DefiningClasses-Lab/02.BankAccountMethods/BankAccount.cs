public class BankAccount
{
    private int id;
    private decimal balance;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public decimal Balance
    {
        get { return balance; }
        set { balance = value; }
    }

    public void Deposit(decimal amount)
    {
        balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        balance -= amount;
    }

    public override string ToString()
    {
        return $"Account {Id}, balance {Balance}";
    }
}
