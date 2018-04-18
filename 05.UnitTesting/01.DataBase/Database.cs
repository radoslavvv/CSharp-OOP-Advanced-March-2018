using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Database
{
    private int[] data;
    private int itemsCount;

    private const int arraySize = 16;

    public Database(params int[] items)
    {
        if (items.Length > 16)
        {
            throw new InvalidOperationException("Database should contain exactly 16 elements!");
        }

        this.data = new int[arraySize];

        for (int i = 0; i < items.Length; i++)
        {
            this.data[i] = items[i];
        }
        this.ItemsCount = items.Length;
    }

    public int ItemsCount { get; private set; }

    public void Add(int item)
    {
        if (this.ItemsCount == 16)
        {
            throw new InvalidOperationException("Database is full!");
        }

        this.data[this.ItemsCount] = item;
        this.ItemsCount++;
    }

    public void Remove()
    {
        if (this.ItemsCount == 0)
        {
            throw new InvalidOperationException("Database is empty");
        }

        this.data[this.ItemsCount - 1] = 0;
        this.ItemsCount--;
    }

    public int[] Fetch()
    {
        return this.data.ToArray();
    }
}

