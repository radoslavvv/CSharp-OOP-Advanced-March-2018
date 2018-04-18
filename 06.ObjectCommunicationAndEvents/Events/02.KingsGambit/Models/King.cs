﻿using System;
using System.Collections.Generic;
using System.Text;

public class King : IKing
{
    public event GetAttackedEventHandler GetAttackedEvent;

    private ICollection<ISubordinate> subordinates;

    public King(string name, ICollection<ISubordinate> subordinates)
    {
        this.Name = name;
        this.subordinates = subordinates;
    }

    public IReadOnlyCollection<ISubordinate> Subordinates => (IReadOnlyCollection<ISubordinate>)this.subordinates;

    public string Name { get; }


    public void GetAttacked()
    {
        Console.WriteLine($"{this.GetType().Name} {this.Name} is under attack!");
        if (GetAttackedEvent != null)
        {
            this.GetAttackedEvent.Invoke();
        }
    }

    public void AddSubordinate(ISubordinate subordinate)
    {
        this.subordinates.Add(subordinate);
        this.GetAttackedEvent += subordinate.ReactToAttack;

        subordinate.DeathEvent += this.OnSubordinateDeath;
    }

    public void OnSubordinateDeath(object sender)
    {
        this.subordinates.Remove((ISubordinate)sender);
    }
}

