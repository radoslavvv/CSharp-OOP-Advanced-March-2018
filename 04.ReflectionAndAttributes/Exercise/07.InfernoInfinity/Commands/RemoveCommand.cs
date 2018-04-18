using System;
using System.Collections.Generic;
using System.Text;

public class RemoveCommand : Command
{
    IWeaponsRepository weaponsRepository;
    IGemFactory gemFactory;
    IWeaponFactory weaponFactory;

    public RemoveCommand(string[] data, IGemFactory gemFactory, IWeaponFactory weaponFactory, IWeaponsRepository weaponsRepository)
        : base(data)
    {
        this.weaponsRepository = weaponsRepository;
        this.weaponFactory = weaponFactory;
        this.gemFactory = gemFactory;
    }

    public override string Execute()
    {
        string weaponName = this.Data[1];
        int socketIndex = int.Parse(this.Data[2]);

        IWeapon weapon = this.weaponsRepository.GetWeapon(weaponName);
        weapon.RemoveGem(socketIndex);

        return null;
    }
}

