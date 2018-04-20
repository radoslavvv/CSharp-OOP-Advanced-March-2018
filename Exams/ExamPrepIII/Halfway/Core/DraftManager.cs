using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private IEnergyRepository ep;
    private IProviderController pc;
    private IHarvesterController hc;
    private UnitsRepo up;

    public DraftManager()
    {
        this.ep = new EnergyRepository();
        this.up = new UnitsRepo();
        this.pc = new ProviderController(this.ep,this.up);
        this.hc = new HarvesterController(this.ep, this.up);
    }
}
