using System;
using System.Collections.Generic;
using System.Text;

public class PersonNameLengthComparator : IComparer<Person>
{
    public int Compare(Person firstPerson, Person secondPerson)
    {
        int comparison = firstPerson.Name.Length.CompareTo(secondPerson.Name.Length);

        if(comparison == 0)
        {
            char firstPersonLetter = char.ToLower(firstPerson.Name[0]);
            char secondPersonLetter = char.ToLower(secondPerson.Name[0]);

            comparison = firstPersonLetter.CompareTo(secondPersonLetter);
        }

        return comparison;
    }
}

