using System;

public interface ISoldier : INameable, IKillable, IHealth
{
    void OnKingAttacked(object sender, EventArgs eventArgs);
}