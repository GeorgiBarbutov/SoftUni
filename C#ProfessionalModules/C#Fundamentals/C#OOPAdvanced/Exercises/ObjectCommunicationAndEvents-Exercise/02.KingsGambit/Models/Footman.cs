public class Footman : Soldier
{
    public Footman(string name) 
        : base(name)
    {
        this.displayMassege = $"Footman {this.Name} is panicking!";
    }
}

