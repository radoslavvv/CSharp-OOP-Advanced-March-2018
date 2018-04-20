using System.Text;

public abstract class Provider : IProvider
{
    private const double StartingDurability = 1000;

    protected Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = StartingDurability;
    }

    public int ID { get; }

    public double EnergyOutput { get; protected set; }

    public double Durability { get; protected set; }


    public void Broke()
    {
        this.Durability -= 100;
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability = StartingDurability;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.GetType().Name}");
        sb.AppendLine($"Durability: {this.Durability}");

        return sb.ToString().Trim();
    }
}