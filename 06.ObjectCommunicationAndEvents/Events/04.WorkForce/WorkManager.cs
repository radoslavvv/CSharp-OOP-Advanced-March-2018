using System;
using System.Collections.Generic;
using System.Text;

public class WorkManager
{
    private Dictionary<string, IEmployable> employees;
    private Dictionary<string, Job> jobs;

    public WorkManager()
    {
        this.employees = new Dictionary<string, IEmployable>();
        this.jobs = new Dictionary<string, Job>();
    }

    public void CreateJob(string[] data)
    {
        string name = data[1];
        int workHours = int.Parse(data[2]);
        IEmployable employee = employees[data[3]];

        Job currentJob = new Job(name, workHours, employee);

        this.jobs.Add(name, currentJob);
    }

    public void Status()
    {
        foreach (var job in this.jobs)
        {
            if (!job.Value.IsDone)
            {
                Console.WriteLine(job.Value);
            }
        }
    }

    public void AddEmployee(string[] data)
    {
        string employeeType = data[0];
        string employeeName = data[1];

        Type type = Type.GetType(employeeType);
        Employee employee = (Employee)Activator.CreateInstance(type, new object[] { employeeName });

        employees.Add(employeeName, employee);
    }

    public void PassWeek()
    {
        foreach (var job in this.jobs)
        {
            if (!job.Value.IsDone)
            {
                job.Value.Update();
            }
        }
    }
}
