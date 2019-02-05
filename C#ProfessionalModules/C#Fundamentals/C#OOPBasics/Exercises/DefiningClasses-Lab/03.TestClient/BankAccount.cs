public class BankAccount
{
    private int id;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    private decimal balance;

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

    public override string ToString() => $"Account ID{Id}, balance {Balance:f2}";
}
