using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Room
{
    public Pet Pet { get; private set; }

    public bool IsEmpty => this.Pet == null;

    public override string ToString()
    {
        if (this.IsEmpty)
        {
            return $"Room empty";
        }
        else
        {
            return ($"{this.Pet.Name} {this.Pet.Age} {this.Pet.Kind}");
        }
    }

    public void AddPet(Pet pet)
    {
        this.Pet = pet;
    }

    public void ReleasePet()
    {
        this.Pet = null;
    }
}

