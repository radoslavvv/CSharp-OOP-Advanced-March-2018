using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class CustomStack<T> : IEnumerable<T>
{
    private List<T> elements;

    public CustomStack()
    {
        elements = new List<T>();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.elements.Count- 1; i >= 0; i--)
        {
            yield return this.elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public void Push(params T[] elements)
    {
        for (int i = 0; i < elements.Length; i++)
        {
            this.elements.Add(elements[i]);
        }
    }

    public T Pop()
    {
        int index = this.elements.Count - 1;

        if (index < 0)
        {
            throw new ArgumentException("No elements");
        }

        T element = this.elements[index];
        this.elements.RemoveAt(index);

        return element;
    }
}
