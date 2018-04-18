using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        WorkManager wm = new WorkManager();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] data = input.Split();

            switch (data[0])
            {
                case "Job":
                    wm.CreateJob(data);
                    break;
                case "Status":
                    wm.Status();
                    break;
                case "Pass":
                    wm.PassWeek();
                    break;
                case "StandardEmployee":
                    wm.AddEmployee(data);
                    break;
                case "PartTimeEmployee":
                    wm.AddEmployee(data);
                    break;
            }
        }
    }
}

