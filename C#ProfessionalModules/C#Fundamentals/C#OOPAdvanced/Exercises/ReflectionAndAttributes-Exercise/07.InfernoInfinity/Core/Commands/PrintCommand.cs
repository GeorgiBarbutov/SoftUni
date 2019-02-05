using System;
using System.Collections.Generic;
using System.Linq;

public class PrintCommand : IExecutable
{
    private string weaponName;
    private IList<IWeapon> weapons;

    public PrintCommand(string weaponName, IList<IWeapon> weapons)
    {
        this.weaponName = weaponName;
        this.weapons = weapons;
    }

    public void Execute()
    {
        IWeapon weapon = this.weapons.FirstOrDefault(x => x.Name == weaponName);

        if (weapon != null)
        {
            Console.WriteLine(weapon);
        }
    }
}
