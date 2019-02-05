public class Tomcat : Cat
{
    public override string ProduceSound()
    {
        return "MEOW";
    }

    public const string Gender = "Male";

    public Tomcat(string name, int age) : base(name, age, Gender)
    { }
}