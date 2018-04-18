using System;
using System.Collections.Generic;
using System.Text;

public class TrafficLight
{
    public TrafficLight(string light)
    {
        this.Light = (Light)Enum.Parse(typeof(Light), light);
    }

    public Light Light { get; set; }

    public void ChangeLight()
    {
        this.Light++;

        if ((int)this.Light > 3)
        {
            this.Light = (Light)1;
        }
    }

    public override string ToString()
    {
        return $"{this.Light.ToString()}";
    }
}

