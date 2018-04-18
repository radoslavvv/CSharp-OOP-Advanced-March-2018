using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

public class AddCommand : Command
{
    [Inject]
    private IRepository repo;
    [Inject]
    private IUnitFactory unitFactory;

    public AddCommand(string[] data, IRepository repo, IUnitFactory unitFactory)
        : base(data)
    {
        this.Repo = repo;
        this.UnitFactory = unitFactory;
    }

    protected IRepository Repo
    {
        get => repo;
        private set => repo = value;
    }

    protected IUnitFactory UnitFactory
    {
        get => unitFactory;
        private set => unitFactory = value;
    }

    public override string Execute()
    {
        string unitType = this.Data[1];
        IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);

        this.Repo.AddUnit(unitToAdd);
        string output = unitType + " added!";

        return output;
    }
}
