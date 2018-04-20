using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Assassin : AbstractHero
{
    private const int BaseStrength = 25;
    private const int BaseAgility = 100;
    private const int BaseIntelligence = 15;
    private const int BaseHitPoints = 150;
    private const int BaseDamage = 300;

    public Assassin(string name)
        : base(name, BaseStrength, BaseAgility, BaseIntelligence, BaseHitPoints, BaseDamage)
    {
    }
}

