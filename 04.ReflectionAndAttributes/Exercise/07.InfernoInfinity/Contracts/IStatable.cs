using System;
using System.Collections.Generic;
using System.Text;

public interface IStatable
{
    double MaxDamage { get; }
    double MinDamage { get; }

    double Strength { get; }
    double Agility { get; }
    double Vitality { get; }
}

