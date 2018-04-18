using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<TrafficLight> traficLights = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(i => new TrafficLight(i))
            .ToList();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            ChangeLights(traficLights);

            PrintTrafficLights(traficLights);
        }
    }

    private static void PrintTrafficLights(List<TrafficLight> traficLights)
    {
        Console.WriteLine($"{string.Join(" ", traficLights)}");
    }

    private static void ChangeLights(List<TrafficLight> traficLights)
    {
        foreach (var trafficLight in traficLights)
        {
            trafficLight.ChangeLight();
        }
    }
}

