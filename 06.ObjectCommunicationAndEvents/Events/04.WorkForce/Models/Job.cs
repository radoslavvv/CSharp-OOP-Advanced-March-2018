using System;
using System.Collections.Generic;
using System.Text;

public class Job
{
    private string name;
    private int hoursOfWorkRequired;
    private IEmployable employee;
    public Job(string name, int hoursOfWorkRequired, IEmployable employee)
    {
        this.employee = employee;
        this.name = name;
        this.hoursOfWorkRequired = hoursOfWorkRequired;
        this.IsDone = false;
    }
    public bool IsDone { get; private set; }

    public void Update()
    {
        this.hoursOfWorkRequired -= this.employee.WorkHours;
        if(this.hoursOfWorkRequired <= 0)
        {
            Console.WriteLine($"Job {this.name} done!");
            this.IsDone = true;
        }
    }

    public override string ToString()
    {
        return $"Job: {this.name} Hours Remaining: {this.hoursOfWorkRequired}";
    }
}

