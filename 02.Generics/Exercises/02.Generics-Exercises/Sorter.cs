using System;
using System.Collections.Generic;
using System.Text;

public class Sorter
{
    public static CustomList<T> Sort<T>(CustomList<T> list) 
        where T:IComparable<T>
    {

        for (int i = 0; i < list.Items.Count - 1; i++)
        {
            for (int j = i + 1; j > 0; j--)
            {
                if (list.Items[j - 1].CompareTo(list.Items[j]) == 1)
                {
                    T temp = list.Items[j - 1];
                    list.Items[j - 1] = list.Items[j];
                    list.Items[j] = temp;
                }
            }
        }

        return list;
    }
}

