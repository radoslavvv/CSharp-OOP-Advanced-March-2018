using System;

public class Program
{
    public static void Main()
    {
        INameChangeable dispatcher = new Dispatcher();
        INameChangeHandler handler = new Handler();

        dispatcher.NameChange += handler.OnDispatcherNameChange;

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            dispatcher.Name = input;
        }

    }
}

