using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class CommandInterpreter : ICommandInterpreter
{
    private IWeaponsRepository weaponsRepository;
    private IWeaponFactory weaponFactory;
    private IGemFactory gemFactory;

    public CommandInterpreter(IGemFactory gemFactory, IWeaponFactory weaponFactory, IWeaponsRepository weaponsRepository)
    {
        this.weaponsRepository = weaponsRepository;
        this.weaponFactory = weaponFactory;
        this.gemFactory = gemFactory;
    }

    public IExecutable InterpretCommand(string[] data, string commandName)
    {
        Assembly assembly = Assembly.GetCallingAssembly();

        Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name == commandName + "Command");

        IExecutable instance = (IExecutable)Activator.CreateInstance(commandType, new object[] { data, this.gemFactory, this.weaponFactory, this.weaponsRepository });

        return instance;
    }
}

