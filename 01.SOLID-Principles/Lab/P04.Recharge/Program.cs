using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        ISleeper employee = new Employee("Employee1");
        IRechargeable robot = new Robot("Robot1", 10);

        List<IRechargeable> irechargeables = new List<IRechargeable>();
        irechargeables.Add(robot);

        ChargingStation cs = new ChargingStation(irechargeables);
        cs.Recharge();
    }
}

