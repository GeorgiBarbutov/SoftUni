public class Extraordinaire : Cat
{
    public int Decibels { get; private set; }
    public string Type { get; private set; }

    public Extraordinaire(string name, int decibels, string type) : base(name)
    {
        Decibels = decibels;
        Type = type;
    }
    public override string ToString()
    {
        return $"{Type} {Name} {Decibels}";
    }
}
