using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Class1
{
    private ProviderController providerController;
    private EnergyRepository energyRepository;

    [SetUp]
    public void SetUpProviderController()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(energyRepository);
    }

    [Test]
    public void ProducesCorrectAmountOfEnergy()
    {
        List<string> firstSolarProvider = new List<string>()
        {
            "Solar", "1", "100"
        };

        List<string> secondSolarProvider = new List<string>()
        {
            "Solar", "2", "100"
        };

        this.providerController.Register(firstSolarProvider);
        this.providerController.Register(secondSolarProvider);

        this.providerController.Produce();

        Assert.That(this.providerController.TotalEnergyProduced, Is.EqualTo(200));
    }

    // 50/50
    [Test]
    public void ProducesCorrectAmountOfEnergyString()
    {
        List<string> firstSolarProvider = new List<string>()
        {
            "Solar", "1", "100"
        };

        List<string> secondSolarProvider = new List<string>()
        {
            "Solar", "2", "100"
        };

        this.providerController.Register(firstSolarProvider);
        this.providerController.Register(secondSolarProvider);


        Assert.That(this.providerController.Produce, Is.EqualTo("Produced 200 energy today!"));
    }

    [Test]
    public void BrokenProviderIsDeleted()
    {
        List<string> firstProvider = new List<string>()
        {
            "Pressure", "1", "100","100"
        };

        this.providerController.Register(firstProvider);

        for (int i = 0; i < 10; i++)
        {
            this.providerController.Produce();
        }


        Assert.That(this.providerController.Entities.Count, Is.EqualTo(0));
    }

    [Test]
    public void ProvidersGetRepaired()
    {
        List<string> firstProvider = new List<string>()
        {
            "Solar", "1", "100"
        };

        this.providerController.Register(firstProvider);

        this.providerController.Repair(100);

        Assert.That(this.providerController.Entities.First().Durability, Is.EqualTo(1600));
    }
}

