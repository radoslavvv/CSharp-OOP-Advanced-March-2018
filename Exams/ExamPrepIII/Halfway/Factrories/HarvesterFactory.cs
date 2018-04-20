using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class HarvesterFactory : IHarvesterFactory
{
    public IHarvester GenerateHarvester(IList<string> args)
    {
        args = args.Skip(2).ToList();

        string harvesterType = args[0];

        int id = int.Parse(args[1]);
        double oreOutput = double.Parse(args[2]);
        double energyReq = double.Parse(args[3]);

        Type type = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == harvesterType + "Harvester");

        ConstructorInfo ctor = type
            .GetConstructors(BindingFlags.Public | BindingFlags.Instance)
            .First();

        IHarvester harvester = (IHarvester)ctor
            .Invoke(new object[] { id, oreOutput, energyReq });

        return harvester;
    }
}