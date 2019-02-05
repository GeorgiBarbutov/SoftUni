public class Owl : Bird
{
    private const double WEIGHT_INCREASE = 0.25;
    private const string SOUND = "Hoot Hoot";

    public Owl(string name, double weight, double wingSize) 
        : base(name, weight, wingSize, new string[1] { "Meat" } , WEIGHT_INCREASE)
    {
    }

    public override void MakeSound()
    {
        System.Console.WriteLine(SOUND);
    }
}

