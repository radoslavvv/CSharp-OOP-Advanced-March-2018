using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        //first tuple
        string[] data = Console.ReadLine().Split();

        string firstName = $"{data[0]} {data[1]}";
        string city = data[2];
        Tuple<string, string> firstTuple = new Tuple<string, string>(firstName, city);

        //second tuple
        data = Console.ReadLine().Split();

        string secondName = data[0];
        int amountOfBeer = int.Parse(data[1]);
        Tuple<string, int> secondTuple = new Tuple<string, int>(secondName, amountOfBeer);

        //third tuple
        data = Console.ReadLine().Split();

        int paramOne = int.Parse(data[0]);
        double paramTwo = double.Parse(data[1]);
        Tuple<int, double> thirdTuple = new Tuple<int, double>(paramOne, paramTwo);

        Console.WriteLine(firstTuple);
        Console.WriteLine(secondTuple);
        Console.WriteLine(thirdTuple);
    }
}

