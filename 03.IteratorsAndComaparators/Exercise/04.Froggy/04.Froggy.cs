using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        List<int> input = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

        Lake lake = new Lake(input);

        Console.WriteLine($"{string.Join(", ", lake)}");
    }
}

