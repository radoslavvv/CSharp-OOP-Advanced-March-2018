using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShutdownCommand : Command
{
    private DraftManager dm;
    private IHarvesterController hc;
    private IProviderController pc;
    private UnitsRepo up;
    private IEnergyRepository ep;

    public ShutdownCommand(IList<string> args, DraftManager dm, IHarvesterController hc, IProviderController pc, UnitsRepo up, IEnergyRepository ep)
        : base(args)
    {
        this.dm = dm;
        this.pc = pc;
        this.hc = hc;
        this.up = up;
        this.ep = ep;
    }

    public override string Execute()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Produced: {this.pc.TotalEnergyProduced}");
        sb.AppendLine($"Total Mined Plumbus Ore: {this.hc.OreProduced}");

        return sb.ToString().Trim();
    }
}

