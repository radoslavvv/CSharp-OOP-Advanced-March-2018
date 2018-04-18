using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        SortedSet<Person> firstSet = new SortedSet<Person>();
        HashSet<Person> secondSet = new HashSet<Person>();

        int peopleCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < peopleCount; i++)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string name = input[0];
            int age = int.Parse(input[1]);

            Person currentPerson = new Person(name, age);

            firstSet.Add(currentPerson);
            secondSet.Add(currentPerson);
        }

        Console.WriteLine(firstSet.Count);
        Console.WriteLine(secondSet.Count);
    }
}

