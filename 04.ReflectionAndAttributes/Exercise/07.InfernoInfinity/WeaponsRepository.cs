using System;
using System.Collections.Generic;
using System.Text;

public class WeaponsRepository : IWeaponsRepository
{
    private Dictionary<string, IWeapon> weapons;
    private WeaponFactory weaponFactory;
    private GemFactory gemFactory;

    public WeaponsRepository()
    {
        this.weapons = new Dictionary<string, IWeapon>();
        this.weaponFactory = new WeaponFactory();
        this.gemFactory = new GemFactory();
    }

    public IWeapon GetWeapon(string weaponName)
    {
        if (this.weapons.ContainsKey(weaponName))
        {
            return weapons[weaponName];
        }

        return null;
    }

    public void AddWeapon(string name, IWeapon weapon)
    {
        this.weapons.Add(name, weapon);
    }
}

