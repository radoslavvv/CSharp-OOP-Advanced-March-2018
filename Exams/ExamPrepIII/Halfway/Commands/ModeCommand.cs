using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ModeCommand : Command
{
    private DraftManager dm;
    private IHarvesterController hc;
    private IProviderController pc;
    private UnitsRepo up;
    private IEnergyRepository ep;

    public ModeCommand(IList<string> args, DraftManager dm, IHarvesterController hc, IProviderController pc, UnitsRepo up, IEnergyRepository ep)
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
        string mode = this.Arguments[1];

        string result = this.hc.ChangeMode(mode);
        return result;
    }
}

