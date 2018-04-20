using System;

public class InfinityHarvester : Harvester
{
    private const int PermanentDurability = 1000;
    private const int OreOutputDivider = 10;

    public InfinityHarvester(int id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput /= OreOutputDivider;
    }

}