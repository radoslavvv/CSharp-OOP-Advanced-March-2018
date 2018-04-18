using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class SimpleSortedList<T> : ISimpleOrderedBag<T> where T : IComparable<T>
{
    private const int DefaultSize = 16;

    private T[] innerCollection;
    private int size;
    private IComparer<T> comparison;

    private void InitializeInnerCollection(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentException("Capacity connot be negative!");
        }

        this.innerCollection = new T[capacity];
    }

    public SimpleSortedList(IComparer<T> comparer, int capacity)
    {
        this.comparison = comparer;
        this.InitializeInnerCollection(capacity);
    }

    public SimpleSortedList(int capacity)
        : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), capacity)
    {
    }

    public SimpleSortedList(IComparer<T> comparer)
        : this(comparer, DefaultSize)
    {
    }

    public SimpleSortedList()
        : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), DefaultSize)
    {
    }

    public int Size => this.size;

    public int Capacity => this.innerCollection.Length;

    public void Add(T element)
    {
        if (element == null)
        {
            throw new ArgumentNullException("Element is null!");
        }

        if (this.innerCollection.Length <= this.size)
        {
            Resize();
        }

        this.innerCollection[size] = element;
        this.size++;
        Array.Sort(this.innerCollection, 0, size, comparison);
    }
    private void Resize()
    {
        T[] newCollection = new T[this.size * 2];
        Array.Copy(innerCollection, newCollection, this.size);
        innerCollection = newCollection;
    }
    public void AddAll(ICollection<T> collection)
    {
        if (collection == null)
        {
            throw new ArgumentNullException("Collection is null!");
        }

        if (this.size + collection.Count >= this.innerCollection.Length)
        {
            this.MultiResize(collection);
        }

        foreach (var element in collection)
        {
            this.innerCollection[this.size] = element;
            this.size++;
        }

        Array.Sort(this.innerCollection, 0, this.size, this.comparison);
    }

    private void MultiResize(ICollection<T> collection)
    {
        int newSize = this.innerCollection.Length * 2;
        while (this.size + collection.Count >= newSize)
        {
            newSize *= 2;
        }

        T[] newCollection = new T[newSize];
        Array.Copy(this.innerCollection, newCollection, this.size);
        this.innerCollection = newCollection;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.size; i++)
        {
            yield return this.innerCollection[i];
        }
    }

    public string JoinWith(string joiner)
    {
        if (joiner == null)
        {
            throw new ArgumentNullException("Joiner is null!");
        }

        StringBuilder sb = new StringBuilder();
        foreach (var element in this)
        {
            sb.Append(element);
            sb.Append(joiner);
        }

        sb.Remove(sb.Length - joiner.Length, joiner.Length);

        return sb.ToString();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public bool Remove(T element)
    {
        if (element == null)
        {
            throw new ArgumentNullException("Element is null!");
        }

        bool hasBeenRemoved = false;
        int indexOfRemovedElement = 0;
        for (int i = 0; i < this.Size; i++)
        {
            if (this.innerCollection[i].Equals(element))
            {
                indexOfRemovedElement = i;
                this.innerCollection[i] = default(T);
                hasBeenRemoved = true;
                break;
            }
        }

        if (hasBeenRemoved)
        {
            for (int i = indexOfRemovedElement; i < this.Size - 1; i++)
            {
                this.innerCollection[this.size - 1] = default(T);
            }
            this.size--;
        }

        return hasBeenRemoved;
    }
}

