using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string name)
    {
        Assembly assembly = Assembly.GetCallingAssembly();
        Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == name);

        if (!typeof(IAmmunition).IsAssignableFrom(type))
        {
            //throw exception
        }

        return (IAmmunition)Activator.CreateInstance(type);
    }
}
