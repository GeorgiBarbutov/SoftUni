public class Spy : Soldier, ISpy
{
    public Spy(string id, string firstName, string lastName, int codeNumber)
        : base(id,firstName,lastName)
    {
        this.CodeNumber = codeNumber;
    }

    public override string ToString()
    {
        return base.ToString() + $" \r\nCode Number: {this.CodeNumber}";
    }

    public int CodeNumber { get; private set; }
}

