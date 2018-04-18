using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        List<Person> people = new List<Person>();

        while (input != "END")
        {
            string[] data = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string name = data[0];
            int age = int.Parse(data[1]);
            string town = data[2];

            Person currentPerson = new Person(name, age, town);
            people.Add(currentPerson);

            input = Console.ReadLine();
        }

        int personIndex = int.Parse(Console.ReadLine());
        Person comparablePerson = people[personIndex - 1];

        int equalPeopleCount = 0;
        int notEqualPeopleCount = 0;
        int totalPeopleCount = people.Count;

        foreach (var person in people)
        {
            int comparisonResult = comparablePerson.CompareTo(person);
            if (comparisonResult == 0)
            {
                equalPeopleCount++;
            }
            else
            {
                notEqualPeopleCount++;
            }
        }

        if (equalPeopleCount == 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{equalPeopleCount} {notEqualPeopleCount} {totalPeopleCount}");
        }
    }
}

