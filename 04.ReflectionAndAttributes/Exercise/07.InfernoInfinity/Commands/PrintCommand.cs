using System;
using System.Collections.Generic;
using System.Text;

public class PrintCommand : Command
{
    private IWeaponFactory weaponFactory;
    private IWeaponsRepository weaponsRepository;
    private IGemFactory gemFactory;

    public PrintCommand( string[] data, IGemFactory gemFactory, IWeaponFactory weaponFactory, IWeaponsRepository weaponsRepository)
        : base(data)
    {
        this.weaponsRepository = weaponsRepository;
        this.weaponFactory = weaponFactory;
        this.gemFactory = gemFactory;
    }

    public override string Execute()
    {
        string weaponName = this.Data[1];
        IWeapon weapon = this.weaponsRepository.GetWeapon(weaponName);

        return weapon.ToString();
    }
}
