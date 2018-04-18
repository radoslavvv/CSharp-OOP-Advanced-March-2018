using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ClinicManager
{
    private Dictionary<string, Clinic> clinics;
    private Dictionary<string, Pet> pets;

    public ClinicManager()
    {
        this.clinics = new Dictionary<string, Clinic>();
        this.pets = new Dictionary<string, Pet>();
    }

    public void Print(params string[] data)
    {
        string clinicName = data[1];

        Clinic currentClinic = clinics[clinicName];
        if (data.Length == 2)
        {
            foreach (var room in currentClinic.Rooms.OrderBy(c => c.Key))
            {
                Console.WriteLine(room.Value);
            }
        }
        else
        {
            int roomNumber = int.Parse(data[2]);
            Console.WriteLine(clinics[clinicName].Rooms[roomNumber]);
        }
    }

    public bool HasEmptyRooms(string clinicName)
    {
        bool hasEmptyRooms = clinics[clinicName].Rooms.Any(r => r.Value.IsEmpty);

        return hasEmptyRooms;
    }

    public bool Release(string clinicName)
    {
        int clinicRoomsCount = clinics[clinicName].Rooms.Count;

        int roomIndex = (clinicRoomsCount / 2) + 1;

        if (clinicRoomsCount == 1)
        {
            if (clinics[clinicName].Rooms[1].IsEmpty)
            {
                return false;
            }
            else
            {
                clinics[clinicName].Rooms[1].ReleasePet();
                return true;
            }
        }

        bool petIsReleased = false;

        while (!petIsReleased)
        {
            if (!clinics[clinicName].Rooms[roomIndex].IsEmpty)
            {
                clinics[clinicName].Rooms[roomIndex].ReleasePet();

                petIsReleased = true;

                break;
            }
            else
            {
                roomIndex++;
                if (roomIndex == clinicRoomsCount)
                {
                    roomIndex = 0;
                }
            }
        }

        return petIsReleased;
    }

    public bool Add(params string[] data)
    {
        string petName = data[1];
        string clinicName = data[2];

        int clinicRoomsCount = clinics[clinicName].Rooms.Count;
        int roomIndex = (clinicRoomsCount / 2) + 1;

        Pet pet = pets[petName];

        int counter = 1;
        bool petIsAdded = false;

        while (roomIndex > 0 && roomIndex <= clinicRoomsCount)
        {
            if (clinics[clinicName].Rooms[roomIndex].IsEmpty)
            {
                clinics[clinicName].Rooms[roomIndex].AddPet(pet);

                petIsAdded = true;

                break;
            }

            counter++;

            if (counter % 2 == 0)
            {
                roomIndex -= counter - 1;
            }
            else
            {
                roomIndex += counter - 1;
            }
        }

        return petIsAdded;
    }

    public void Create(params string[] data)
    {
        if (data.Length == 5)
        {
            string petName = data[2];
            int petAge = int.Parse(data[3]);
            string petKind = data[4];

            Pet currentPet = new Pet(petName, petAge, petKind);

            pets.Add(petName, currentPet);
        }
        else if (data.Length == 4)
        {
            string clinicName = data[2];
            int clinicRoomsCount = int.Parse(data[3]);

            Clinic currentClinic = new Clinic(clinicRoomsCount);

            clinics.Add(clinicName, currentClinic);
        }
    }
}

