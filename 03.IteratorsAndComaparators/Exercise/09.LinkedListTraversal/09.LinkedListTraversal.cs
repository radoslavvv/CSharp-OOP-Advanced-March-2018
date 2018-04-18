using System;

public class Program
{
    public static void Main()
    {
        int commandsCount = int.Parse(Console.ReadLine());

        LinkedList<int> linkedList = new LinkedList<int>();

        for (int i = 0; i < commandsCount; i++)
        {
            string[] data = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string command = data[0];
            int item = int.Parse(data[1]);

            switch (command)
            {
                case "Add":
                    linkedList.Add(item);
                    break;
                case "Remove":
                    linkedList.Remove(item);
                    break;
            }
        }

        Console.WriteLine(linkedList.Count);
        Console.WriteLine(string.Join(" ", linkedList));
    }
}

