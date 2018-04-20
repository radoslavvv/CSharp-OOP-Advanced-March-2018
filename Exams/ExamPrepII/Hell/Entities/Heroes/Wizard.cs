using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Wizard : AbstractHero
{
    private const int BaseStrength = 25;
    private const int BaseAgility = 25;
    private const int BaseIntelligence = 100;
    private const int BaseHitPoints = 100;
    private const int BaseDamage = 250;

    public Wizard(string name)
        : base(name, BaseStrength, BaseAgility, BaseIntelligence, BaseHitPoints, BaseDamage)
    {
    }
}

