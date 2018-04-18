using System;
using System.Collections.Generic;
using System.Text;

public class AddCommand : Command
{
    private IGemFactory gemFactory;
    private IWeaponsRepository weaponsRepository;
    private IWeaponFactory weaponFactory;

    public AddCommand(string[] data, IGemFactory gemFactory, IWeaponFactory weaponFactory, IWeaponsRepository weaponsRepository) :
        base(data)
    {
        this.weaponsRepository = weaponsRepository;
        this.weaponFactory = weaponFactory;
        this.gemFactory = gemFactory;
    }

    public override string Execute()
    {
        string weaponName = this.Data[1];
        int socketIndex = int.Parse(this.Data[2]);

        IGem gem = this.gemFactory.CreateGem(this.Data);
        IWeapon weapon = this.weaponsRepository.GetWeapon(weaponName);

        weapon.AddGem(socketIndex, gem);

        return null;
    }
}

