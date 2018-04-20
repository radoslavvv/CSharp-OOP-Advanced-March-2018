public interface IWareHouse
{
    void EquipArmy(IArmy army);

    void AddAmmonition(string ammoName, int quantity);

    bool TryToEquipSoldier(ISoldier soldier);
}