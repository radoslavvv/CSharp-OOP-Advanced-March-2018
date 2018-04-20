using System;
using System.Collections.Generic;
using System.Linq;

public class Engine 
{
    private DraftManager manager;
    private CommandInterpreter ci;

    private IWriter writer;
    private IReader reader;
    private IHarvesterController hc;
    private IProviderController pc;
    private IEnergyRepository ep;
    private UnitsRepo up;

    public Engine(IWriter writer, IReader reader)
    {
        this.ep = new EnergyRepository();
        this.manager = new DraftManager();
        this.up = new UnitsRepo();
        this.hc = new HarvesterController(ep,this.up);
        this.pc = new ProviderController(ep, this.up);


        this.ci = new CommandInterpreter(this.manager, this.hc, this.pc, this.up, this.ep);

        this.writer = writer;
        this.reader = reader;
    }

    public void Run()
    {
        while (true)
        {
            var input = this.reader.ReadLine();
            var data = input.Split().ToList();
            var command = data[0];

            this.writer.WriteLine(ci.ProcessCommand(data));
            if(command == "Shutdown")
            {
                Environment.Exit(0);
            }
        }
    }
}
