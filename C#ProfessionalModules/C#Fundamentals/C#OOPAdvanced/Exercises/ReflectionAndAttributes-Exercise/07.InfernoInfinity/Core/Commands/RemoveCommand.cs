using System.Collections.Generic;
using System.Linq;

public class RemoveCommand : IExecutable
{
    private string weaponName;
    private IList<IWeapon> weapons;
    private int socketIndex;

    public RemoveCommand(string weaponName, int socketIndex, IList<IWeapon> weapons)
    {
        this.weaponName = weaponName;
        this.weapons = weapons;
        this.socketIndex = socketIndex;
    }

    public void Execute()
    {
        IWeapon weapon = this.weapons.FirstOrDefault(x => x.Name == weaponName);

        if(weapon != null)
        {
            weapon.RemoveGem(socketIndex);
        }
    }
}
