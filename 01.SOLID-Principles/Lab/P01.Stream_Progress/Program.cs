using System;

public class Program
{
    static void Main()
    {
        IStream fileStream = new File("File", 8, 155);
        IStream musicStream = new Music("Music", "Album", 10, 201);

        StreamProgressInfo spiFiles = new StreamProgressInfo(fileStream);
        StreamProgressInfo spiMusic = new StreamProgressInfo(musicStream);
    }
}

