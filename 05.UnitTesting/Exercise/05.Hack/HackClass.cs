using System;
using System.Collections.Generic;
using System.Text;

public class HackClass 
{
    public HackClass()
    {
        this.HackValue = 0;
    }

    public double HackValue { get;private set; }

    public double FloorValue(double input)
    {
        this.HackValue = Math.Floor(input);

        return this.HackValue;
    }

    public double AbsoluteValue(double input)
    {
        this.HackValue = Math.Abs(input);

        return this.HackValue;
    }
}

