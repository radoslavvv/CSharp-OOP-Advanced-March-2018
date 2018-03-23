using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        CustomList<string> customList = new CustomList<string>();

        string input = Console.ReadLine();
        while (input != "END")
        {
            string[] data = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            CommandInterpreter(customList, data);

            input = Console.ReadLine();
        }
    }

    private static void CommandInterpreter(CustomList<string> customList, string[] data)
    {
        string action = data[0];
        switch (action)
        {
            case "Add":
                customList.Add(data[1]);
                break;
            case "Remove":
                customList.Remove(int.Parse(data[1]));
                break;
            case "Contains":
                Console.WriteLine(customList.Contains(data[1]));
                break;
            case "Swap":
                customList.Swap(int.Parse(data[1]), int.Parse(data[2]));
                break;
            case "Greater":
                Console.WriteLine(customList.CountGreaterThan(data[1]));
                break;
            case "Max":
                Console.WriteLine(customList.Max());
                break;
            case "Min":
                Console.WriteLine(customList.Min());
                break;
            case "Print":
                customList.Print();
                break;
            case "Sort":
                Sorter.Sort(customList);
                break;
        }
    }
}

