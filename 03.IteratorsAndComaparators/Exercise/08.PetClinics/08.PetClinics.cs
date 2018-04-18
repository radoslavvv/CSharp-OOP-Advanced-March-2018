using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        ClinicManager cm = new ClinicManager();
        int commandsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < commandsCount; i++)
        {
            string[] data = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string action = data[0];

            try
            {
                switch (action)
                {
                    case "Create":
                        cm.Create(data);
                        break;
                    case "Add":
                        Console.WriteLine(cm.Add(data));
                        break;
                    case "Release":
                        Console.WriteLine(cm.Release(data[1]));
                        break;
                    case "HasEmptyRooms":
                        Console.WriteLine(cm.HasEmptyRooms(data[1]));
                        break;
                    case "Print":
                        cm.Print(data);
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
