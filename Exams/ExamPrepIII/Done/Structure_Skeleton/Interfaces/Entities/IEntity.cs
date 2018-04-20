﻿using System.Collections.Generic;

public interface IEntity
{
    int ID { get; }

    double Durability { get; }

    double Produce();

    void Broke();
}