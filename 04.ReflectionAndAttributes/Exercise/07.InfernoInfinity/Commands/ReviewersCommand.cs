﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ReviewersCommand : Command
{
    public ReviewersCommand(string[] data, IGemFactory gemFactory, IWeaponFactory weaponFactory, IWeaponsRepository weaponsRepository) : base(data)
    {

    }

    public override string Execute()
    {
        var field = this.Data[0];

        var attribute = typeof(Weapon).GetCustomAttributes(false).FirstOrDefault();
        WeaponAttribute fieldToPrint = (WeaponAttribute)attribute;

        string result = fieldToPrint.Print(field);

        return result;
    }
}

