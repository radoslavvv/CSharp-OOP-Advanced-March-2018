using System;
using System.Collections.Generic;
using System.Text;

public abstract class Employee : IEmployable
{
    public Employee(string name, int workHours)
    {
        this.Name = name;
        this.WorkHours = workHours;
    }

    public string Name { get; }

    public int WorkHours { get; }
}

