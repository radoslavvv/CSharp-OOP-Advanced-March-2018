using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class InspectCommand : Command
{
    private DraftManager dm;
    private IHarvesterController hc;
    private IProviderController pc;
    private UnitsRepo up;
   private IEnergyRepository ep;

    public InspectCommand(IList<string> args, DraftManager dm, IHarvesterController hc, IProviderController pc, UnitsRepo up, IEnergyRepository ep)
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
        int id = int.Parse(this.Arguments[1]);
        StringBuilder sb = new StringBuilder();

        IHarvester harvester = this.up.Harvesters.FirstOrDefault(h => h.ID == id);
        IProvider provider = this.up.Providers.FirstOrDefault(h => h.ID == id);

        if (harvester != null)
        {
            sb.AppendLine(harvester.ToString());
        }

        if (provider != null)
        {
            sb.AppendLine(provider.ToString());
        }

        if (string.IsNullOrWhiteSpace(sb.ToString()))
        {
            sb.AppendLine($"No entity found with id - {id}");
        }

        return sb.ToString().Trim();
    }
}

