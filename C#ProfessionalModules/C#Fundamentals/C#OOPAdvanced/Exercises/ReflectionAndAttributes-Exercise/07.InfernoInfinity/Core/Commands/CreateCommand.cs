using System;
using System.Collections.Generic;

public class CreateCommand : IExecutable
{
    private IWeaponFactory weaponFactory;
    private string weaponType;
    private string weaponName;
    private IList<IWeapon> weapons;

    public CreateCommand(string weaponType, string weaponName, IList<IWeapon> weapons)
    {
        this.weaponFactory = new WeaponFactory();
        this.weaponType = weaponType;
        this.weaponName = weaponName;
        this.weapons = weapons;
    }

    public void Execute()
    {
        IWeaponFactory weaponFactory = new WeaponFactory();
        IWeapon weapon = weaponFactory.CreateWeapon(weaponType.Split(' ')[1], weaponName, Enum.Parse<Rarity>(weaponType.Split(' ')[0]));

        this.weapons.Add(weapon);
    }
}

