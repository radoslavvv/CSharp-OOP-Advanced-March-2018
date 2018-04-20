using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShutdownCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public ShutdownCommand(IList<string> args, IHarvesterController harvesterController, IProviderController providerController)
        : base(args)
    {
        this.providerController = providerController;
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(Constants.SystemShutdown);
        sb.AppendLine(string.Format(Constants.TotalEnergyProduced, this.providerController.TotalEnergyProduced));
        sb.Append(string.Format(Constants.TotalMinedOre, this.harvesterController.OreProduced));

        return sb.ToString();
    }
}

