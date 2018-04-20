using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BubbleSort<T> : IEnumerable<T>
    where T : IComparable
{
    private IList<T> data;

    public BubbleSort(params T[] items)
    {
        this.data = items.ToList();

        this.Sort();
    }

    public int ItemsCount => this.data.Count;

    public void AddItem(T item)
    {
        this.data.Add(item);
    }

    public T RemoveItem(T item)
    {
        if (!this.data.Contains(item))
        {
            throw new ArgumentException($"{item} isn't present in the list!");
        }

        int removedItemIndex = this.data.IndexOf(item);
        T removedItem = this.data[removedItemIndex];
        this.data.RemoveAt(removedItemIndex);

        return removedItem;
    }

    private void Sort()
    {
        bool arrayIsSorted = false;
        while (!arrayIsSorted)
        {
            arrayIsSorted = true;
            for (int i = 0; i < data.Count - 1; i++)
            {
                T currentItem = data[i];
                T nextItem = data[i + 1];

                if (currentItem.CompareTo(nextItem) == 1)
                {
                    T temp = currentItem;
                    data[i] = data[i + 1];
                    data[i + 1] = temp;

                    arrayIsSorted = false;
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.data.GetEnumerator();
    }
}

