public class Kitten : Cat
{
    public override string ProduceSound()
    {
        return "Meow";
    }

    public const string Gender = "Female";

    public Kitten(string name, int age) : base(name, age, Gender)
    {
    }
}