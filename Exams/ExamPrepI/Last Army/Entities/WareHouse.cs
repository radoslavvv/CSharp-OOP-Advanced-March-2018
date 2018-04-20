using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WareHouse : IWareHouse
{
    private Dictionary<string, int> ammunitionsQuantities;
    private IAmmunitionFactory ammunitionFactory;

    public WareHouse()
    {
        this.ammunitionsQuantities = new Dictionary<string, int>();
        this.ammunitionFactory = new AmmunitionFactory();
    }

    public void AddAmmonition(string ammoName, int quantity)
    {
        if (ammunitionsQuantities.ContainsKey(ammoName))
        {
            ammunitionsQuantities[ammoName] += quantity;
        }
        else
        {
            ammunitionsQuantities.Add(ammoName, quantity);
        }
    }

    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers)
        {
            TryToEquipSoldier(soldier);
        }
    }

    public bool TryToEquipSoldier(ISoldier soldier)
    {
        var wornOutWeapons = soldier.Weapons
            .Where(w => w.Value == null).Select(w => w.Key).ToList();

        var soldierIsEquipped = true;
        foreach (var weapon in wornOutWeapons)
        {
            if (ammunitionsQuantities.ContainsKey(weapon) && ammunitionsQuantities[weapon] > 0)
            {
                var createdWeapon = ammunitionFactory.CreateAmmunition(weapon);

                soldier.Weapons[weapon] = createdWeapon;
                ammunitionsQuantities[weapon]--;
            }
            else
            {
                soldierIsEquipped = false;
            }
        }

        return soldierIsEquipped;
    }
}

