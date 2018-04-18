using _03BarracksFactory.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        IWeaponsRepository weaponsRepository = new WeaponsRepository();
        IWeaponFactory weaponFactory = new WeaponFactory();
        IGemFactory gemFactory = new GemFactory();

        ICommandInterpreter commandInterpreter = new CommandInterpreter(gemFactory, weaponFactory, weaponsRepository);

        Engine engine = new Engine(commandInterpreter);
        engine.Run();
    }
}

