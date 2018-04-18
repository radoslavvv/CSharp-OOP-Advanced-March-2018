using System;
using System.Collections.Generic;
using System.Text;

public class PersonAgeComparator : IComparer<Person>
{
    public int Compare(Person firstPerson, Person secondPerson)
    {
        int comparison = firstPerson.Age.CompareTo(secondPerson.Age);

        return comparison;
    }
}

