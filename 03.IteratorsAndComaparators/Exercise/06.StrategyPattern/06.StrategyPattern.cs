using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        SortedSet<Person> firstSet = new SortedSet<Person>(new PersonNameLengthComparator());
        SortedSet<Person> secondSet = new SortedSet<Person>(new PersonAgeComparator());

        int linesCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < linesCount; i++)
        {
            string[] data = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string name = data[0];
            int age = int.Parse(data[1]);

            Person currentPerson = new Person(name, age);

            firstSet.Add(currentPerson);
            secondSet.Add(currentPerson);
        }

        foreach (Person person in firstSet)
        {
            Console.WriteLine(person);
        }

        foreach (Person person in secondSet)
        {
            Console.WriteLine(person);
        }
    }
}

