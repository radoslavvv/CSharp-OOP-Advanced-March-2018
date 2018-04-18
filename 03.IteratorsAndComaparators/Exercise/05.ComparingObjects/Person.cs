using System;
using System.Collections.Generic;
using System.Text;

public class Person : IComparable<Person>
{
    public Person(string name, int age, string town)
    {
        this.Name = name;
        this.Age = age;
        this.Town = town;
    }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public string Town { get; private set; }

    public int CompareTo(Person otherPerson)
    {
        int nameComparison = this.Name.CompareTo(otherPerson.Name);
        int ageComparison = this.Age.CompareTo(otherPerson.Age);
        int townComparison = this.Town.CompareTo(otherPerson.Town);

        if (nameComparison == 0)
        {
            if(ageComparison == 0)
            {
                return townComparison;
            }
            return ageComparison;
        }
        return nameComparison;
    }
}

