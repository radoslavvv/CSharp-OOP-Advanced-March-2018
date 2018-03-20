using System;
using System.Collections.Generic;
using System.Text;

public class Employee
{
    public Employee(string name)
    {
        this.Name = name;
    }

    public string Name { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Name}");

        return sb.ToString().Trim();
    }
}

