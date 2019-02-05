public class Private : Soldier, IPrivate
{
    public Private(string id, string firstName, string lastName, double salary)
        : base(id,firstName,lastName)
    {
        this.Salary = salary;
    }

    public override string ToString()
    {
        return base.ToString() + $" Salary: {this.Salary:f2}";
    }

    public double Salary { get; private set; }
}

