using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DayCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public DayCommand(IList<string> args, IHarvesterController harvesterController, IProviderController providerController)
        : base(args)
    {
        this.providerController = providerController;
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        string providersResult = this.providerController.Produce();
        string harvestersResult = this.harvesterController.Produce();

        return $"{providersResult}\r\n" +
                $"{harvestersResult}";
    }
}

