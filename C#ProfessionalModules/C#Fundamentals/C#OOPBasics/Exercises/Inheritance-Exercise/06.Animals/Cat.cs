public class Cat : Animal
{
    public override string ProduceSound()
    {
        return "Meow meow";
    }

    public Cat(string name, int age, string gender) : base(name, age, gender)
    { }
}