using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        Assembly assembly = Assembly.GetCallingAssembly();
        Type type = assembly
            .GetTypes()
            .FirstOrDefault(t => t.Name == soldierTypeName);

        if (!typeof(ISoldier).IsAssignableFrom(type))
        {
            //throw exception
        }

        return (ISoldier)Activator.CreateInstance(type,
            name, age, experience, endurance);
    }
}
