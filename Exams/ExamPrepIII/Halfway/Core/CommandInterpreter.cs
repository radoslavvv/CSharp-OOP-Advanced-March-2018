using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class CommandInterpreter : ICommandInterpreter
{
    public IHarvesterController HarvesterController => this.hc;

    public IProviderController ProviderController => this.pc;

    private DraftManager dm;
    private IHarvesterController hc;
    private IProviderController pc;
    private UnitsRepo up;
    private IEnergyRepository ep;

    public CommandInterpreter(DraftManager dm, IHarvesterController hc, IProviderController pc, UnitsRepo up, IEnergyRepository ep)
    {
        this.dm = dm;
        this.hc = hc;
        this.pc = pc;
        this.up = up;
        this.ep = ep;
    }

    public string ProcessCommand(IList<string> args)
    {
        var commandName = args[0];
        Type type = Assembly.GetCallingAssembly().GetTypes().First(t => t.Name == commandName + "Command");

        var command = (ICommand)Activator.CreateInstance(type, args, dm, hc, pc, up, ep);

        string result = command.Execute();
        return result.Trim();
    }
}
