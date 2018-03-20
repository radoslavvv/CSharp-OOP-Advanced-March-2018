﻿using System;

public class Program
{
    static void Main()
    {
        GraphicEditor ge = new GraphicEditor();
        IShape circle = new Circle();
        IShape rectangle = new Rectangle();
        IShape square = new Square();

        ge.DrawShape(circle);
        ge.DrawShape(rectangle);
        ge.DrawShape(square);
    }
}

