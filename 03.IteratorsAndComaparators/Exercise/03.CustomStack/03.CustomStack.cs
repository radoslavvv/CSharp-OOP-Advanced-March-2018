using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        CustomStack<int> stack = new CustomStack<int>();

        string[] data = Console.ReadLine()
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        try
        {
            string command = data[0];
            while (command != "END")
            {
                switch (command)
                {
                    case "Pop":
                        stack.Pop();
                        break;
                    case "Push":
                        int[] elements = data.Skip(1).Select(int.Parse).ToArray();
                        stack.Push(elements);
                        break;
                }

                data = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                command = data[0];
            }

        }catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }


        foreach (var item in stack)
        {
            Console.WriteLine(item);
        }
        foreach (var item in stack)
        {
            Console.WriteLine(item);
        }
    }
}

