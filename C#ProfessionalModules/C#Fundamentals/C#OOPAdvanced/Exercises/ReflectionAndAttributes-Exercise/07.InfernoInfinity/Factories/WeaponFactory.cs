using System;

public class WeaponFactory : IWeaponFactory
{
    public IWeapon CreateWeapon(string weaponType, string name, Rarity rarity)
    {
        Type type = Type.GetType(weaponType);

        IWeapon weapon = (IWeapon)Activator.CreateInstance(type, new object[] { name, rarity });

        return weapon;
    }
}

