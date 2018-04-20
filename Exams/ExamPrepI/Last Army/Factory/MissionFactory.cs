using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        Assembly assembly = Assembly.GetCallingAssembly();
        Type type = assembly
            .GetTypes()
            .FirstOrDefault(t => t.Name == difficultyLevel);

        if (!typeof(IMission).IsAssignableFrom(type))
        {
            //throw exception
        }

        return (IMission)Activator.CreateInstance(type,
            neededPoints);
    }
}

