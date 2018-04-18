using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

public class ReportCommand : Command
{
    [Inject]
    private IRepository repo;

    public ReportCommand(string[] data, IRepository repo) 
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
        string output = this.Repo.Statistics;

        return output;
    }
}

