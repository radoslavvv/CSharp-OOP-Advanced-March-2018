public interface IWeaponsRepository
{
    IWeapon GetWeapon(string weaponName);
    void AddWeapon(string name, IWeapon weapon);
}