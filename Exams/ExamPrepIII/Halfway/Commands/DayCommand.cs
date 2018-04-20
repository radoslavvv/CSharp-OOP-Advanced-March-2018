using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DayCommand : Command
{
    private DraftManager dm;
    private IHarvesterController hc;
    private IProviderController pc;
    private UnitsRepo up;
    private IEnergyRepository ep;

    public DayCommand(IList<string> args, DraftManager dm, IHarvesterController hc, IProviderController pc, UnitsRepo up, IEnergyRepository ep)
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
        sb.AppendLine(this.pc.Produce());
        sb.AppendLine(this.hc.Produce());

        return sb.ToString().Trim();
    }
}


