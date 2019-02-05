public class Cymric : Cat
{
    public double FurLenght { get; private set; }
    public string Type { get; private set; }

    public Cymric(string name, double furLenght, string type) : base(name)
    {
        FurLenght = furLenght;
        Type = type;
    }
    public override string ToString()
    {
        return $"{Type} {Name} {FurLenght:f2}";
    }
}

