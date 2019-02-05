using System;

public class GemFactory : IGemFactory
{
    public IGem CreateGem(string gemType, Clarity clarity)
    {
        Type type = Type.GetType(gemType);

        IGem gem = (IGem)Activator.CreateInstance(type, new object[] { clarity });

        return gem;
    }
}

