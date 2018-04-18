public class CreateCommand : Command
{
    private IWeaponFactory weaponFactory;
    private IWeaponsRepository weaponsRepository;
    private IGemFactory gemFactory;

    public CreateCommand( string[] data, IGemFactory gemFactory, IWeaponFactory weaponFactory, IWeaponsRepository weaponsRepository) : base(data)
    {
        this.weaponsRepository = weaponsRepository;
        this.weaponFactory = weaponFactory;
        this.gemFactory = gemFactory;
    }

    public override string Execute()
    {
        IWeapon weapon = this.weaponFactory.CreateWeapon(this.Data);
        this.weaponsRepository.AddWeapon(weapon.Name, weapon);

        return null;
    }
}

