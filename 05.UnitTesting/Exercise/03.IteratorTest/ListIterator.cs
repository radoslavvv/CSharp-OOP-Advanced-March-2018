using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ListIterator
{
    private IList<string> items;
    private int index;

    public ListIterator(params string[] items)
    {
        this.items = new List<string>();

        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                throw new ArgumentNullException("Item cannot be null!");
            }

            this.items.Add(items[i]);
        }

        this.index = 0;
    }

    public bool Move()
    {
        if (this.HasNext())
        {
            this.index++;

            return true;
        }

        return false;
    }

    public string Print()
    {
        if (this.items.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        return this.items[index];
    }

    public bool HasNext()
    {
        bool hasNext = this.index + 1 < this.items.Count;

        return hasNext;
    }
}

