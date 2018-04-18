using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[WeaponAttribute("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
public abstract class Weapon : IWeapon
{
    private double minDamage;
    private double maxDamage;

    public Weapon(string type, string name, double minDamage, double maxDamage, int socketsCount)
    {
        this.Type = (WeaponType)Enum.Parse(typeof(WeaponType), type);
        this.Sockets = new Gem[socketsCount];
        this.Name = name;
        this.MinDamage = minDamage;
        this.MaxDamage = maxDamage;
    }

    public WeaponType Type { get; private set; }

    public string Name { get; private set; }

    public IGem[] Sockets { get; private set; }

    public double MinDamage
    {
        get { return minDamage * (int)this.Type + this.Strength * 2 + this.Agility * 1; }
        private set { minDamage = value; }
    }

    public double MaxDamage
    {
        get { return maxDamage * (int)this.Type + this.Strength * 3 + this.Agility * 4; }
        private set { maxDamage = value; }
    }

    public double Strength
    {
        get { return this.Sockets.Where(s => s != null).Sum(s => s.Strength); }
    }


    public double Agility
    {
        get { return this.Sockets.Where(s => s != null).Sum(s => s.Agility); }

    }

    public double Vitality
    {
        get { return this.Sockets.Where(s => s != null).Sum(s => s.Vitality); }
    }

    public void AddGem(int index, IGem gem)
    {
        if (index >= 0 && index < this.Sockets.Length)
        {
            this.Sockets[index] = gem;
        }
    }

    public void RemoveGem(int index)
    {
        if (index >= 0 && index < this.Sockets.Length)
        {
            this.Sockets[index] = null;
        }
    }

    public override string ToString()
    {
        return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{this.Strength} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";
    }
}

