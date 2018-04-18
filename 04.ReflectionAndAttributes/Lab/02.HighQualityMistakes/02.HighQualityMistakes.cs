using System;

public class Program
{
    public static void Main()
    {
        Spy spy = new Spy();
        string result = spy.AnalyzeAccessModifiers("System.Text.StringBuilder");

        Console.WriteLine(result);
    }
}

