public class RoyalGuard : Soldier
{
    public RoyalGuard(string name)
        : base(name)
    {
        this.displayMassege = $"Royal Guard {this.Name} is defending!";
    }
}

