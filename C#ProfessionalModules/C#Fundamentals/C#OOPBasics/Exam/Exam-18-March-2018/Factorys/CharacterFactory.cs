using System;

public class CharacterFactory
{
    public CharacterFactory()
    {

    }

    public Character CreateCharacter(string faction, string characterType, string name)
    {
        if (characterType != "Warrior" && characterType != "Cleric")
        {
            throw new ArgumentException($"Invalid character type \"{characterType}\"!");
        }

        if (faction != "CSharp" && faction != "Java")
        {
            throw new ArgumentException($"Invalid faction \"{faction}\"!");
        }

        if (characterType == "Warrior")
        {
            return new Warrior(name, Enum.Parse<Faction>(faction));
        }
        else if (characterType == "Cleric")
        {
            return new Cleric(name, Enum.Parse<Faction>(faction));
        }

        return null;
    }
}

