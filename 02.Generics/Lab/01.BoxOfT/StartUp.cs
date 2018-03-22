using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        Box<int> box = new Box<int>();
        box.Add(1);
        box.Add(2);
        Console.WriteLine(box.Remove());
        Console.WriteLine(box.Count);

        Box<string> box2 = new Box<string>();
        box2.Add("one");
        box2.Add("two");
        Console.WriteLine(box2.Remove());
        Console.WriteLine(box2.Count);
    }
}

