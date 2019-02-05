public abstract class Animal
{
    private string name;
    private string favouriteFood;

    public Animal(string name, string favouriteFood)
    {
        this.Name = name;
        this.FavouriteFood = favouriteFood;
    }

    public abstract string ExplainSelf();

    public string FavouriteFood
    {
        get { return favouriteFood; }
        private set { favouriteFood = value; }
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }
}

