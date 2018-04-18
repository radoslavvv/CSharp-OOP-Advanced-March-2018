using System;
using System.Collections.Generic;
using System.Text;

public abstract class Subordinate : ISubordinate
{
    public event SubordinateDeathEventHandler DeathEvent;

    public Subordinate(string name, string action, int hitPoints)
    {
        this.Name = name;
        this.IsAlive = true;
        this.Action = action;
        this.HitPoints = hitPoints;
    }

    public string Name { get; }

    public bool IsAlive { get; private set; }

    public string Action { get; }

    public int HitPoints { get; private set; }

    public void Die()
    {
        this.IsAlive = false;
        if(this.DeathEvent != null)
        {
            this.DeathEvent.Invoke(this);
        }
    }

    public virtual void ReactToAttack()
    {
        if (this.IsAlive)
        {
            Console.WriteLine($"{this.GetType().Name} {this.Name} is {this.Action}!");
        }
    }

    public void TakeDamage()
    {
        this.HitPoints--;
        if(this.HitPoints <= 0)
        {
            this.Die();
        }
    }
}

