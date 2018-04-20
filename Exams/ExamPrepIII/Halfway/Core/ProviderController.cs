using System;
using System.Collections.Generic;
using System.Linq;

public class ProviderController : IProviderController
{
    private List<IProvider> providers;
    private IEnergyRepository energyRepository;
    private IProviderFactory factory;
    private UnitsRepo up;

    public ProviderController(IEnergyRepository energyRepository, UnitsRepo up)
    {
        this.energyRepository = energyRepository;
        this.providers = new List<IProvider>();
        this.factory = new ProviderFactory();
        this.up = up;
    }

    public double TotalEnergyProduced { get; private set; }

    public IReadOnlyCollection<IEntity> Entities => this.providers.AsReadOnly();

    public string Register(IList<string> arguments)
    {
        var provider = this.factory.GenerateProvider(arguments);

        this.providers.Add(provider);

        this.up.AddProvider(provider);

        return string.Format(Constants.SuccessfullRegistration,
            provider.GetType().Name);
    }

    public string Produce()
    {
        double energyProduced = this.providers.Select(n => n.Produce()).Sum();

        this.energyRepository.StoreEnergy(energyProduced);
        this.TotalEnergyProduced += energyProduced;

        foreach (var provider in this.providers)
        {
            provider.Broke();
        }

        this.providers = this.providers.Where(p => p.Durability > 0).ToList();

        return string.Format(Constants.EnergyOutputToday, energyProduced);
    }

    public string Repair(double val)
    {
        foreach (var provider in this.providers)
        {
            provider.Repair(val);
        }

        return string.Format(Constants.ProvidersRepaired, val);
    }
}