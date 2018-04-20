using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

public class ExtendedDatabase
{
    private IPerson[] data;
    private const int arraySize = 16;

    public ExtendedDatabase(params IPerson[] items)
    {
        if (items.Length > 16)
        {
            throw new InvalidOperationException("Database should contain exactly 16 elements!");
        }

        this.data = new Person[arraySize];

        for (int i = 0; i < items.Length; i++)
        {
            this.data[i] = items[i];
        }
        this.ItemsCount = items.Length;
    }

    public int ItemsCount { get; private set; }

    public void Add(IPerson item)
    {
        if (this.ItemsCount == 16)
        {
            throw new InvalidOperationException("Database is full!");
        }

        for (int i = 0; i < this.ItemsCount; i++)
        {
            if (this.data[i].Id.Equals(item.Id))
            {
                throw new InvalidOperationException("A person with the same Id already exists in the database!");
            }

            if (this.data[i].Username.Equals(item.Username))
            {
                throw new InvalidOperationException("A person with the same username already exists in the database!");
            }
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

        this.data[this.ItemsCount - 1] = null;
        this.ItemsCount--;
    }

    public IPerson FindByUsername(string username)
    {
        if (username == null)
        {
            throw new ArgumentNullException(username, "Username parameter is null!");
        }

        for (int i = 0; i < this.ItemsCount; i++)
        {
            if (this.data[i].Username.Equals(username))
            {
                return this.data[i];
            }
        }

        throw new InvalidOperationException("No person with this username is present in the database!");
    }

    public IPerson FindById(long id)
    {
        if (id < 0)
        {
            throw new ArgumentOutOfRangeException("Id cant't be negative!");
        }

        for (int i = 0; i < this.ItemsCount; i++)
        {
            if (this.data[i].Id.Equals(id))
            {
                return this.data[i];
            }
        }

        throw new InvalidOperationException("No person with this id is present in the database!");
    }

    public IPerson[] Fetch()
    {
        return this.data.ToArray();
    }
}

