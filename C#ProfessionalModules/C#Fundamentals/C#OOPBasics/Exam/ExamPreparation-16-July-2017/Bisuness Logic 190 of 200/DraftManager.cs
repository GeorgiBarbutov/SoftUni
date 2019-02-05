using System;
using System.Collections.Generic;
using System.Linq;

public class DraftManager
{
    private string mode;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private List<Provider> providers;
    private List<Harvester> harvesters;

    public DraftManager()
    {
        this.ModeChanger = "Full";
        this.TotalStoredEnergy = 0;
        this.TotalMinedOre = 0;
        this.providers = new List<Provider>();
        this.harvesters = new List<Harvester>();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            Harvester harvester = HarvesterFactory.CreateHarvester(arguments);
            this.harvesters.Add(harvester);

            return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
        }
        catch (ArgumentException e)
        {
            return e.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double energyOutput = double.Parse(arguments[2]);

        try
        {
            Provider provider = ProviderFactory.CreateProvider(arguments);
            this.providers.Add(provider);

            return $"Successfully registered {type} Provider - {id}";
        }
        catch (ArgumentException e)
        {
            return e.Message;
        }
    }

    public string Day()
    {
        double summedEnergyOutput = 0;
        foreach (var provider in this.providers)
        {
            summedEnergyOutput += provider.EnergyOutput;
        }
        this.TotalStoredEnergy += summedEnergyOutput;

        double EnergyRequiredMultiplyer = 1;
        double oreOutputMultiplier = 1;
        if (mode == "Full")
        {
            EnergyRequiredMultiplyer = 1;
            oreOutputMultiplier = 1;
        }
        else if(mode == "Half")
        {
            EnergyRequiredMultiplyer = 0.6;
            oreOutputMultiplier = 0.5;
        }
        else if (mode == "Energy")
        {
            EnergyRequiredMultiplyer = 0;
            oreOutputMultiplier = 0;
        }

        double totalNeededEnergy = 0;
        foreach (var harvester in this.harvesters)
        {
            totalNeededEnergy += (harvester.EnergyRequirement * EnergyRequiredMultiplyer);
        }

        double summedOreOutput = 0;
        if (this.TotalStoredEnergy >= totalNeededEnergy)
        {
            this.TotalStoredEnergy -= totalNeededEnergy;

            foreach (var harvester in harvesters)
            {
                summedOreOutput += (harvester.OreOutput * oreOutputMultiplier);
            }
            this.TotalMinedOre += summedOreOutput;
        }

        return "A day has passed." + Environment.NewLine +
            $"Energy Provided: {summedEnergyOutput}" + Environment.NewLine +
            $"Plumbus Ore Mined: {summedOreOutput}";
    }

    public string Mode(List<string> arguments)
    {
        string mode = arguments[0];

        if (mode == "Full")
        {
            this.ModeChanger = mode;
        }
        else if (mode == "Half")
        {
            this.ModeChanger = mode;
        }
        else if (mode == "Energy")
        {
            this.ModeChanger = mode;
        }

        return $"Successfully changed working mode to {mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];

        Unit unit = providers.FirstOrDefault(x => x.Id == id);
        
        if(unit != null)
        {
            return unit.ToString();
        }
        else
        {
            unit = harvesters.FirstOrDefault(x => x.Id == id);

            if (unit != null)
            {
                return unit.ToString();
            }
            else
            {
                return $"No element found with id - {id}";
            }
        }
    }
    public string ShutDown()
    {
        return "System Shutdown" + Environment.NewLine +
            $"Total Energy Stored: {this.TotalStoredEnergy}" + Environment.NewLine +
            $"Total Mined Plumbus Ore: {this.TotalMinedOre}";
    }

    private string ModeChanger
    {
        get { return mode; }
        set { mode = value; }
    }

    private double TotalMinedOre
    {
        get { return totalMinedOre; }
        set { totalMinedOre = value; }
    }

    private double TotalStoredEnergy
    {
        get { return totalStoredEnergy; }
        set { totalStoredEnergy = value; }
    }
}

