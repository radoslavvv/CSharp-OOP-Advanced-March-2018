using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UnitsRepo
{
    public UnitsRepo()
    {
        this.Providers = new List<IProvider>();
        this.Harvesters = new List<IHarvester>();
    }

    public List<IProvider> Providers { get;  set; }
    public List<IHarvester> Harvesters { get;  set; }

    public void AddProvider(IProvider provider)
    {
        this.Providers.Add(provider);
    }

    public void AddHarvester(IHarvester harvester)
    {
        this.Harvesters.Add(harvester);
    }
}
