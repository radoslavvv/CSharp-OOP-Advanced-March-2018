using NUnit.Framework;
using System;

public class Class1
{
    [Test]
    public void MisssionControllerDisplaysFailMessage()
    {
        var army = new Army();
        var wareHouse = new WareHouse();

        var missionController = new MissionController(army, wareHouse);

        var mission = new Easy(1);

        string result = "";
        for (int i = 0; i < 4; i++)
        {
            result = missionController.PerformMission(mission);
        }

        Assert.IsTrue(result.Contains("declined"));
    }
    [Test]
    public void MisssionControllerDisplaysSuccessMessage()
    {
        var army = new Army();
        var wareHouse = new WareHouse();

        var missionController = new MissionController(army, wareHouse);

        var mission = new Easy(0);

        string result = missionController.PerformMission(mission);

        Assert.IsTrue(result.Contains("completed"));
    }

}
