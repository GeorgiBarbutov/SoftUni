using System.Collections.Generic;
using System.Linq;

public class Trainer
{
    public string Name { get; private set; }
    public int NumberOfBadges { get; private set; }
    private List<Pokemon> Pokemons { get; set; }

    public Trainer(string name, Pokemon pokemon)
    {
        Name = name;
        NumberOfBadges = 0;
        Pokemons = new List<Pokemon>();
        Pokemons.Add(pokemon);
    }

    public void AddPokemonToList(Pokemon pokemon)
    {
        Pokemons.Add(pokemon);
    }

    public void CheckForElement(string element)
    {
        bool hasAny = Pokemons.Any(x => x.Element == element);

        if(hasAny)
        {
            NumberOfBadges++;
        }
        else
        {
            DecreasePokemonsHealth();
        }
    }

    public int NumberOfPokemons()
    {
        return Pokemons.Count;
    }

    private void DecreasePokemonsHealth()
    {
        for (int i = 0; i < Pokemons.Count; i++)
        {
            int newHealth = Pokemons[i].DecreaseHealth(10);

            if (newHealth <= 0)
            {
                Pokemons.RemoveAt(i);
            }
        }
    }
}
