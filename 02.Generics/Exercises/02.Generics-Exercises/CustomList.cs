using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomList<T>
    where T : IComparable<T>
{
    public CustomList()
    {
        this.Items = new List<T>();
    }

    public List<T> Items { get; }

    public void Add(T element)
    {
        this.Items.Add(element);
    }

    public T Remove(int index)
    {
        T removedItem = this.Items[index];
        this.Items.RemoveAt(index);

        return removedItem;
    }

    public bool Contains(T element)
    {
        foreach (var item in this.Items)
        {
            if (item.Equals(element))
            {
                return true;
            }
        }
        return false;
    }

    public void Swap(int indexOne, int indexTwo)
    {
        T temp = this.Items[indexOne];
        this.Items[indexOne] = this.Items[indexTwo];
        this.Items[indexTwo] = temp;

    }

    public int CountGreaterThan(T element)
    {
        int count = 0;
        foreach (var item in this.Items)
        {
            if (item.CompareTo(element) == 1)
            {
                count++;
            }
        }

        return count;
    }

    public T Max()
    {
        return this.Items.Max();
    }

    public T Min()
    {
        return this.Items.Min();
    }

    public void Print()
    {
        foreach (var item in this.Items)
        {
            Console.WriteLine(item);
        }

    }
}

