using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

public class RetireCommand : Command
{
    [Inject]
    private IRepository repo;

    public RetireCommand(string[] data, IRepository repo)
        : base(data)
    {
        this.Repo = repo;
    }

    protected IRepository Repo
    {
        get => repo;
        private set => repo = value;
    }

    public override string Execute()
    {
        string unitType = this.Data[1];

        try
        {
            this.Repo.RemoveUnit(unitType);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        return $"{unitType} retired!";
    }
}

