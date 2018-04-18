using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class WeaponFactory : IWeaponFactory
{
    public IWeapon CreateWeapon(string[] data)
    {
        string rarity = data[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
        string weaponKind = data[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];

        string weaponName = data[2];

        Assembly assembly = Assembly.GetCallingAssembly();

        Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == weaponKind);

        if (type == null)
        {
            throw new ArgumentException("Invalid Type!");
        }

        if (!typeof(IWeapon).IsAssignableFrom(type))
        {
            throw new ArgumentException("Invalid parameter!");
        }

        var instance = (IWeapon)Activator.CreateInstance(type, new object[] { rarity, weaponName });

        return instance;
    }
}

