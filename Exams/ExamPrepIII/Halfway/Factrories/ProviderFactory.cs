using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class ProviderFactory : IProviderFactory
{
    public IProvider GenerateProvider(IList<string> args)
    {
        args = args.Skip(2).ToList();

        int id = int.Parse(args[1]);
        string harvesterType = args[0];
        double energyOutput = double.Parse(args[2]);

        Type type = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == harvesterType + "Provider");

        ConstructorInfo ctor = type
            .GetConstructors(BindingFlags.Public | BindingFlags.Instance).First();

        IProvider provider = (IProvider)ctor.Invoke(new object[] { id, energyOutput });

        return provider;
    }
}