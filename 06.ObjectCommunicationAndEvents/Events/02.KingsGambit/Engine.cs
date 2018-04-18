using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    private IKing king;

    public Engine(IKing king)
    {
        this.king = king;
    }

    public void Run()
    {
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] data = input.Split();
            string command = data[0];

            if(command == "Attack")
            {
                king.GetAttacked();
            }
            else if(command == "Kill")
            {
                string subName = data[1];
                ISubordinate sub = king.Subordinates.First(s => s.Name == subName);
                sub.TakeDamage();
            }
        }
    }
}

