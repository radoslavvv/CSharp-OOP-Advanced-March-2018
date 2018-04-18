using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class GemFactory : IGemFactory
{
    public IGem CreateGem(string[] data)
    {
        string[] gemInfo = data[3]
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        string gemClarityLevel = gemInfo[0];
        string gemType = gemInfo[1];

        Assembly assembly = Assembly.GetCallingAssembly();

        Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == gemType);

        if (type == null)
        {
            throw new ArgumentException("Invalid Type!");
        }

        if (!typeof(IGem).IsAssignableFrom(type))
        {
            throw new ArgumentException("Invalid parameter!");
        }

        var instance = (IGem)Activator.CreateInstance(type, new object[] { gemClarityLevel });

        return instance;
    }
}

