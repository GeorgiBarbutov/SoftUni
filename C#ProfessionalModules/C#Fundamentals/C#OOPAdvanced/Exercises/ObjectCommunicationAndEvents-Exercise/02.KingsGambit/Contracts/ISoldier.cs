using System;

public interface ISoldier : INameable, IKillable
{
    void OnKingAttacked(object sender, EventArgs eventArgs);
}