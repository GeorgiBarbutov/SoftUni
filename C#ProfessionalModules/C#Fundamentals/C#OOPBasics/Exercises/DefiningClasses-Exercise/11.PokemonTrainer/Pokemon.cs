public class Pokemon
{
    public string Name { get; private set; }
    public string  Element { get; private set; }
    public int Health { get; private set; }

    public Pokemon(string[] pokemonInfo)
    {
        Name = pokemonInfo[0];
        Element = pokemonInfo[1];
        Health = int.Parse(pokemonInfo[2]);
    }

    public int DecreaseHealth(int amount)
    {
        Health -= amount;

        return Health;
    }
}

