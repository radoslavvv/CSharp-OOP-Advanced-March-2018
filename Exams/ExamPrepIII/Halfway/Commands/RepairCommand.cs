using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RepairCommand : Command
{
    private DraftManager dm;
    private IHarvesterController hc;
    private IProviderController pc;
    private UnitsRepo up;
    private IEnergyRepository ep;

    public RepairCommand(IList<string> args, DraftManager dm, IHarvesterController hc, IProviderController pc, UnitsRepo up, IEnergyRepository ep)
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
        double value = double.Parse(this.Arguments[1]);

        return (this.pc.Repair(value).Trim());
    }
}

