using System;
using System.Collections.Generic;
using System.Text;

public class GraphicEditor
{
    public void DrawShape(IShape shape)
    {
        Console.WriteLine(shape.Draw());
    }
}

