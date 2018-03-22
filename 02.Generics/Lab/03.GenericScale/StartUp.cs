using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        IScale<int> intScale = new Scale<int>(5, 3);
        Console.WriteLine(intScale.GetHeavier());

        IScale<string> stringScale = new Scale<string>("First string", "Second string");
        Console.WriteLine(stringScale.GetHeavier());
    }
}

