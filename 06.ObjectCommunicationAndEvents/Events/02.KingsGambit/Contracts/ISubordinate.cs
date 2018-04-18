public delegate void SubordinateDeathEventHandler(object sender);

public interface ISubordinate : INameable, IMortal
{
    event SubordinateDeathEventHandler DeathEvent;

    string Action { get; }

    void ReactToAttack();
}