using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        IKing king = SetUpKing();

        Engine engine = new Engine(king);
        engine.Run();
    }

     private static IKing SetUpKing()
    {
        string kingName = Console.ReadLine();

        IKing king = new King(kingName, new List<ISubordinate>());

        string[] royalGuardNames = Console.ReadLine().Split();

        foreach (var royalGuardName in royalGuardNames)
        {
            king.AddSubordinate(new RoyalGuard(royalGuardName));
        }

        string[] footmenNames = Console.ReadLine().Split();
        foreach (var footmanName in footmenNames)
        {
            king.AddSubordinate(new Footman(footmanName));
        }

        return king;
    }
}

