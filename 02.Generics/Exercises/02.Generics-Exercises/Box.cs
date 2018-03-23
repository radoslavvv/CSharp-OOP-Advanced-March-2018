using System;
using System.Collections.Generic;
using System.Text;

public class Box<T>
    where T : IComparable
{
    public Box(T item)
    {
        this.Item = item;
    }

    public T Item { get; }

    public override string ToString()
    {
        return $"{typeof(T).FullName}: {this.Item}";
    }

    public static List<Box<T>> Swap(List<Box<T>> list, int indexOne, int indexTwo)
    {
        Box<T> temp = list[indexOne];
        list[indexOne] = list[indexTwo];
        list[indexTwo] = temp;

        return list;
    }

    public static int Count(List<Box<T>> list, T element)
    {
        int count = 0;
        foreach (var box in list)
        {
            if (box.Item.CompareTo(element) == 1)
            {
                count++;
            }
        }
        return count;
    }
}

