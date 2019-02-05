public abstract class Food : IFood
{
    public Food(string type, int quantity)
    {
        this.Type = type;
        this.Quantity = quantity;
    }

    public string Type { get; private set; }
    public int Quantity { get; private set; }
}

