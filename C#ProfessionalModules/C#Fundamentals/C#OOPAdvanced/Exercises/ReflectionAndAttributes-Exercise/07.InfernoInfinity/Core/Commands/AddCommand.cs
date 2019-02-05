using System;
using System.Collections.Generic;
using System.Linq;

public class AddCommand : IExecutable
{
    private string weaponName;
    private IList<IWeapon> weapons;
    private int socketIndex;
    private string gemType;
    private IGemFactory gemFactory;

    public AddCommand(string weaponName, int socketIndex, string gemType, IList<IWeapon> weapons)
    {
        this.weaponName = weaponName;
        this.weapons = weapons;
        this.socketIndex = socketIndex;
        this.gemType = gemType;
        this.gemFactory = new GemFactory();
    }

    public void Execute()
    {
        IWeapon weapon = this.weapons.FirstOrDefault(x => x.Name == weaponName);

        if (weapon != null)
        {
            weapon.AddGem(this.gemFactory.CreateGem(gemType.Split(' ')[1], Enum.Parse<Clarity>(gemType.Split(' ')[0]))
                ,this.socketIndex);
        }
    }
}
