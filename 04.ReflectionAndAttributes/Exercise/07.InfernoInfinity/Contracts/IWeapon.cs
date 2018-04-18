public interface IWeapon : IStatable
{
    string Name { get; }

    WeaponType Type { get; }
    IGem[] Sockets { get; }

    void AddGem(int index, IGem gem);
    void RemoveGem(int index);
    string ToString();
}