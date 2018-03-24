using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomList<T>
    where T : IComparable<T>
{
    public CustomList()
    {
        this.Items = new T[4];
        this.Count = 0;
    }

    public T[] Items;

    public int Count { get; private set; }

    public void Add(T element)
    {
        if (this.Count + 1 == this.Items.Length)
        {
            T[] newItemsArray = new T[this.Items.Length * 2];
            Array.Copy(this.Items, newItemsArray, this.Items.Length);


            this.Items = newItemsArray;
        }

        this.Items[this.Count] = element;

        this.Count++;
    }

    public T Remove(int index)
    {
        T removedItem = this.Items[index];
        this.Items[index] = default(T);

        for (int i = index; i < this.Count; i++)
        {
            this.Items[i] = this.Items[i + 1];
        }

        this.Count--;

        if (this.Count < this.Items.Length / 3)
        {
            T[] newItemsArray = new T[this.Items.Length / 2];
            Array.Copy(this.Items, newItemsArray, this.Items.Length);
            this.Items = newItemsArray;
        }

        return removedItem;
    }

    public bool Contains(T element)
    {
        for (int i = 0; i < this.Count; i++)
        {
            T item = this.Items[i];

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
        for (int i = 0; i < this.Count; i++)
        {
            T item = this.Items[i];

            if (item.CompareTo(element) == 1)
            {
                count++;
            }
        }

        return count;
    }

    public T Max()
    {
        T maxItem = this.Items[0];

        bool maxIsFound = false;
        while (!maxIsFound)
        {
            for (int i = 0; i < this.Count; i++)
            {
                T item = this.Items[i];
                if (maxItem.CompareTo(item) == -1)
                {
                    maxItem = item;
                    continue;
                }
            }

            maxIsFound = true;
        }

        return maxItem;
    }

    public T Min()
    {
        T minItem = this.Items[0];

        bool minIsFound = false;
        while (!minIsFound)
        {
            for (int i = 0; i < this.Count; i++)
            {
                T item = this.Items[i];
                if (minItem.CompareTo(item) == 1)
                {
                    minItem = item;
                    continue;
                }
            }

            minIsFound = true;
        }

        return minItem;
    }

    public void Print()
    {
        for (int i = 0; i < this.Count; i++)
        {
            T item = this.Items[i];

            Console.WriteLine(item);
        }
    }
}

