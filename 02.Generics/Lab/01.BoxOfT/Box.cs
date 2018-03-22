using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Box<T> : IBox<T>
{
    private readonly IList<T> elements;

    public Box()
    {
        this.elements = new List<T>();
    }

    public int Count => this.elements.Count;

    public void Add(T element)
    {
        elements.Add(element);
    }

    public T Remove()
    {
        int lastElementIndex = this.Count - 1;
        T removedElement = this.elements[lastElementIndex];

        this.elements.RemoveAt(lastElementIndex);

        return removedElement;
    }

}

