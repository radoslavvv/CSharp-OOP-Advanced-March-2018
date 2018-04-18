using System;
using System.Collections.Generic;

public class Clinic
{
    public Clinic(int roomsCount)
    {
        this.Rooms = new Dictionary<int, Room>();

        if (roomsCount % 2 == 0)
        {
            throw new ArgumentException($"Invalid Operation!");
        }
        else
        {
            for (int i = 1; i <= roomsCount; i++)
            {
                this.Rooms.Add(i, new Room());
            }
        }
    }

    public Dictionary<int, Room> Rooms { get; private set; }

    public int RoomsCount { get; private set; }
}

