using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class InspectCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public InspectCommand(IList<string> args, IHarvesterController harvesterController, IProviderController providerController)
        : base(args)
    {
        this.providerController = providerController;
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        int id = int.Parse(this.Arguments[0]);

        IEntity inspectedEntity = this.harvesterController
            .Entities
            .FirstOrDefault(h => h.ID == id);

        if (inspectedEntity == null)
        {
            inspectedEntity = this.providerController
                .Entities
                .FirstOrDefault(p => p.ID == id);
        }

        if(inspectedEntity == null)
        {
            return string.Format(Constants.EntityNotFound, id);
        }

        return inspectedEntity.ToString();
    }
}

