using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HarvesterController : IHarvesterController
{
    private List<IHarvester> harvesters;
    private IHarvesterFactory hf;
    private IEnergyRepository ep;
    private string mode;
    private UnitsRepo up;

    public HarvesterController(IEnergyRepository ep, UnitsRepo up)
    {
        this.hf = new HarvesterFactory();
        this.harvesters = new List<IHarvester>();
        this.mode = "Full";
        this.ep = ep;
        this.OreProduced = 0;
        this.up = up;
    }

    public double OreProduced { get; private set; }

    public string ChangeMode(string mode)
    {
        if (mode == "Full" || mode == "Half" || mode == "Energy")
        {
            this.mode = mode;
            foreach (var harvester in this.harvesters)
            {
                harvester.Broke();
            }

            this.harvesters = this.harvesters
                .Where(h => h.Durability > 0)
                .ToList();

            this.up.Harvesters = this.harvesters.ToList();
            return $"Mode changed to {mode}!";
        }

        return null;
    }

    public string Produce()
    {
        double neededEnergy = 0;
        foreach (var harvester in this.harvesters)
        {
            if (this.mode == "Full")
            {
                neededEnergy += harvester.EnergyRequirement;
            }
            else if (this.mode == "Half")
            {
                neededEnergy += harvester.EnergyRequirement * 50 / 100;
            }
            else if (this.mode == "Energy")
            {
                neededEnergy += harvester.EnergyRequirement * 20 / 100;
            }
        }

        double minedOres = 0;
        if (this.mode != "Energy")
        {
            if (this.ep.TakeEnergy(neededEnergy))
            {
                foreach (var harvester in this.harvesters)
                {
                    minedOres += harvester.Produce();
                }
            }
        }

        if (this.mode == "Half")
        {
            minedOres = minedOres * 50 / 100;
        }

        this.OreProduced += minedOres;

        return $"Produced {minedOres} ore today!";
    }

    public string Register(IList<string> args)
    {
        var harvester = this.hf.GenerateHarvester(args);

        this.harvesters.Add(harvester);
        this.up.AddHarvester(harvester);
        return string.Format(Constants.SuccessfullRegistration,
            harvester.GetType().Name);
    }
}

