using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class LinkedList<T> : IEnumerable<T>
{
    private List<T> items;

    public LinkedList()
    {
        this.items = new List<T>();
    }

    public int Count => this.items.Count;

    public void Add(T item)
    {
        this.items.Add(item);
    }

    public bool Remove(T item)
    {
        for (int i = 0; i < this.items.Count; i++)
        {
            if(this.items[i].Equals(item))
            {
                this.items.RemoveAt(i);

                return true;
            }
        }

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.items.Count; i++)
        {
            yield return this.items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

