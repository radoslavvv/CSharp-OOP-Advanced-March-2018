using System;
using System.Text;

public class ConsoleWriter : IWriter
{
    private StringBuilder sb;

    public ConsoleWriter()
    {
        this.sb = new StringBuilder();
    }

    public void AppendLine(string line)
    {
        this.sb.AppendLine(line.Trim());
    }

    public void WriteAllLines()
    {
        Console.WriteLine(this.sb.ToString().Trim());
    }
}
