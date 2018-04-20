using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GameController
{
    private IArmy army;
    private IWareHouse wearHouse;

    private MissionController missionController;

    private ISoldierFactory soldierFactory;
    private IMissionFactory missionFactory;

    private IWriter writer;

    public GameController(IWriter writer)
    {
        this.army = new Army();
        this.wearHouse = new WareHouse();
        this.missionController = new MissionController(this.army, this.wearHouse);
        this.soldierFactory = new SoldierFactory();
        this.missionFactory = new MissionFactory();

        this.writer = writer;
    }

    public void GiveInputToGameController(string input)
    {
        var data = input.Split();

        if (data[0].Equals("Soldier"))
        {
            if (data[1] == "Regenerate")
            {
                army.RegenerateTeam(data[2]);
            }
            else
            {
                ISoldier soldier = soldierFactory.CreateSoldier(
                    data[1],
                    data[2],
                    int.Parse(data[3]),
                    double.Parse(data[4]),
                    double.Parse(data[5]));

                if (this.wearHouse.TryToEquipSoldier(soldier))
                {
                    this.army.AddSoldier(soldier);
                }
                else
                {
                    throw new ArgumentException(string.Format(OutputMessages.SoldierCannotBeEquipped, data[1], data[2]));
                }
            }
        }
        else if (data[0].Equals("WareHouse"))
        {
            string name = data[1];
            int quantity = int.Parse(data[2]);

            this.wearHouse.AddAmmonition(name, quantity);
        }
        else if (data[0].Equals("Mission"))
        {
            IMission mission = this.missionFactory.CreateMission(data[1], double.Parse(data[2]));

            writer.AppendLine(this.missionController.PerformMission(mission));
        }
    }

    public void RequestResult()
    {
        this.missionController.FailMissionsOnHold();

        writer.AppendLine("Results:");
        writer.AppendLine($"Successful missions - {this.missionController.SuccessMissionCounter}");
        writer.AppendLine($"Failed missions - {this.missionController.FailedMissionCounter}");
        writer.AppendLine($"Soldiers:");
        foreach (var soldier in this.army.Soldiers.OrderByDescending(s => s.OverallSkill))
        {
            writer.AppendLine(soldier.ToString().Trim());
        }
    }
}
