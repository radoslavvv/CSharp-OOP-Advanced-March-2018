using System;
using System.Collections.Generic;
using System.Text;

public abstract class Gem : IGem
{
    private double strength;
    private double vitality;
    private double agility;

    public Gem(double strength, double agility, double vitality, string clarityLevel)
    {
        this.ClarityLevel = (ClarityLevel)Enum.Parse(typeof(ClarityLevel), clarityLevel);
        this.Strength = strength + (int)this.ClarityLevel;
        this.Agility = agility + (int)this.ClarityLevel;
        this.Vitality = vitality + (int)this.ClarityLevel;
    }

    public ClarityLevel ClarityLevel { get; private set; }

    public double Agility
    {
        get { return agility; }
        private set { agility = value; }
    }

    public double Strength
    {
        get { return strength; }
        private set { strength = value; }
    }

    public double Vitality
    {
        get { return vitality; }
        private set { vitality = value; }
    }
}

