using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Three
{
    public static void Main()
    {
        string[] data = Console.ReadLine().Split();
        string firstName = data[0] + " " + data[1];
        string address = data[2];
        string town = data[3];

        Threeuple<string, string, string> firstThreeuple = new Threeuple<string, string, string>(firstName, address, town);

        data = Console.ReadLine().Split();
        string secondName = data[0];
        int litersOfBeer = int.Parse(data[1]);
        string drunkOrNot = data[2];
        bool isDrunk = drunkOrNot == "drunk" ? true : false;

        Threeuple<string, int, bool> secondThreeuple = new Threeuple<string, int, bool>(secondName, litersOfBeer, isDrunk);

        data = Console.ReadLine().Split();
        string thirdName = data[0];
        double balance = double.Parse(data[1]);
        string bank = data[2];

        Threeuple<string, double, string> thirdThreeuple = new Threeuple<string, double, string>(thirdName, balance, bank);

        Console.WriteLine(firstThreeuple);
        Console.WriteLine(secondThreeuple);
        Console.WriteLine(thirdThreeuple);
    }
}

