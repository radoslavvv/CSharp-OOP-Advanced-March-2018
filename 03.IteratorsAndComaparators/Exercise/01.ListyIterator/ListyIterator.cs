using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ListyIterator<T> : IEnumerable<T>
{
    private IReadOnlyList<T> list;
    private int internalIndex = 0;

    public ListyIterator(List<T> list)
    {
        this.list = list;
    }

    public void Create(params T[] elements)
    {
        if (elements.Length == 0)
        {
            this.list = new List<T>();
        }
        else
        {
            this.list = new List<T>(elements);
        }
    }

    public bool Move()
    {
        if (this.HasNext())
        {
            this.internalIndex++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Print()
    {
        if (this.list.Count == 0)
        {
            Console.WriteLine($"Invalid Operation!");
        }
        else
        {
            Console.WriteLine(this.list[this.internalIndex]);
        }
    }

    public bool HasNext()
    {
        if (this.internalIndex + 1 == this.list.Count)
        {
            return false;
        }

        return true;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.list.Count; i++)
        {
            yield return this.list[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

