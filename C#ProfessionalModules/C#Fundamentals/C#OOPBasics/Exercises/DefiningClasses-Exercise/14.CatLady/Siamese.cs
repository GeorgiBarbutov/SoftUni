public class Siamese : Cat
{
    public int EarSize { get; private set; }
    public string Type { get; private set; }

    public Siamese(string name, int earSize, string type) : base(name)
    {
        EarSize = earSize;
        Type = type;
    }
    public override string ToString()
    {
        return $"{Type} {Name} {EarSize}";
    }
}

