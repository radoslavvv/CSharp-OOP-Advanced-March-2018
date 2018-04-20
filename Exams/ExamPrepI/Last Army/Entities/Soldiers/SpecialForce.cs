using System.Collections.Generic;
using System.Text;

public class SpecialForce : Soldier
{
    private const double overallSkillMiltiplier = 3.5;
    private const int regenerateIncreaseConstant = 30;
    private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "MachineGun",
            "RPG",
            "Helmet",
            "Knife",
            "NightVision"
        };

    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    protected override List<string> WeaponsAllowed => this.weaponsAllowed;

    protected override int RegenerateIncrease => regenerateIncreaseConstant;

    protected override double OverallSkillMultiplier => overallSkillMiltiplier;
}