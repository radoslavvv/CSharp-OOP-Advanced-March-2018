using System;

public abstract class Provider : IProvider
{
    private const double DefautDurability = 1000;

    protected Provider(int id, double energyOutput)
    {
        this.EnergyOutput = energyOutput;
        this.ID = id;
        this.Durability = DefautDurability;
    }

    public double EnergyOutput { get; protected set; }

    public int ID { get; protected set; }

    public double Durability { get; protected set; }


    public void Broke()
    {
        this.Durability -= Constants.DurabilityDecrease;
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}\r\nDurability: {this.Durability}";
    }
}