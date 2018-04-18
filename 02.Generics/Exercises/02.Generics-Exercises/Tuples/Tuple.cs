using System;
using System.Collections.Generic;
using System.Text;

public class Tuple<T1, T2>
{
    private T1 itemOne;
    private T2 itemTwo;

    public Tuple(T1 firstItem, T2 secondItem)
    {
        this.ItemOne = firstItem;
        this.ItemTwo = secondItem;
    }

    public T1 ItemOne
    {
        get { return itemOne; }
        private set { itemOne = value; }
    }

    public T2 ItemTwo
    {
        get { return itemTwo; }
        private set { itemTwo = value; }
    }

    public override string ToString()
    {
        return $"{this.ItemOne} -> {this.ItemTwo}";
    }
}

