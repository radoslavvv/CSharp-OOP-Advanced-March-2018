using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Threeuple<T1, T2, T3>
{
    private T1 firstItem;
    private T2 secondItem;
    private T3 thirdItem;

    public Threeuple(T1 firstItem, T2 secondItem, T3 thirdItem)
    {
        this.FirstItem = firstItem;
        this.SecondItem = secondItem;
        this.ThirdItem = thirdItem;
    }

    public T1 FirstItem
    {
        get { return firstItem; }
        private set { firstItem = value; }
    }

    public T2 SecondItem
    {
        get { return secondItem; }
        private set { secondItem = value; }
    }

    public T3 ThirdItem
    {
        get { return thirdItem; }
        private set { thirdItem = value; }
    }

    public override string ToString()
    {
        return $"{this.FirstItem} -> {this.SecondItem} -> {this.ThirdItem}";
    }
}

