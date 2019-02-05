public abstract class Human : IBuyer
{
    public Human(string name, int age)
    {
        this.Name = name;
        this.Age = age;

        this.Food = 0;
    }

    public string Name { get; protected set; }
    public int Age { get; protected set; }
    public int Food  { get; protected set; }

    public abstract int BuyFood();
}