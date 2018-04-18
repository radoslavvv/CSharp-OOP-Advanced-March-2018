using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<string> data = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        ListyIterator<string> li = new ListyIterator<string>(data.Skip(1).ToList());

        string input = Console.ReadLine();
        while (input != "END")
        {
            data = input.
                Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            ProccessCommand(data, li);

            input = Console.ReadLine();
        }
    }

    private static void ProccessCommand(List<string> data, ListyIterator<string> li)
    {
        string command = data[0];
        switch (command)
        {
            case "Print":
                li.Print();
                break;
            case "HasNext":
                Console.WriteLine(li.HasNext());
                break;
            case "Move":
                Console.WriteLine(li.Move());
                break;
            case "PrintAll":
                Console.WriteLine($"{string.Join(" ", li)}");
                break;
        }
    }
}

