using System.Collections.Generic;

public class HarvesterFactory
{
    public static Harvester CreateHarvester(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double oreOutput = double.Parse(arguments[2]);
        double energyRequirement = double.Parse(arguments[3]);

        if(type == "Hammer")
        {
            return new HammerHarvester(id, oreOutput, energyRequirement);
        }
        else if(type == "Sonic")
        {
            return new SonicHarvester(id, oreOutput, energyRequirement, int.Parse(arguments[4]));
        }
        else
        {
            return null;
        }
    }
}

