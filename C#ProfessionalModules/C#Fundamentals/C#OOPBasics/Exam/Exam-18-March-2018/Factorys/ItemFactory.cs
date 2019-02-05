using System;

public class ItemFactory
{
    public ItemFactory()
    {

    }

    public Item CreateItem(string itemName)
    {
        if (itemName != "ArmorRepairKit" && itemName != "HealthPotion" && itemName != "PoisonPotion")
        {
            throw new ArgumentException($"Invalid item type \"{itemName}\"!");
        }

        if (itemName == "ArmorRepairKit")
        {
            return new ArmorRepairKit();
        }
        else if (itemName == "HealthPotion")
        {
            return new HealthPotion();
        }
        else if (itemName == "PoisonPotion")
        {
            return new PoisonPotion();
        }

        return null;
    }
}

