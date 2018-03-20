using System;
using System.Collections.Generic;
using System.Text;

public class ChargingStation
{
    private List<IRechargeable> irechargeables;

    public ChargingStation(List<IRechargeable> irechargeables)
    {
        this.irechargeables = irechargeables;
    }

    public void Recharge()
    {
        foreach (var irechargeable in irechargeables)
        {
            irechargeable.Recharge();
        }
    }
}

