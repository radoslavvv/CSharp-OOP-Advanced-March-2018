using LoggerExerciese;
using LoggerExerciese.Models.Factories;
using System;

public class Engine
{
    private ILogger logger;
    private ErrorFactory errorFactory;

    public Engine(ILogger logger, ErrorFactory errorFactory)
    {
        this.logger = logger;
        this.errorFactory = errorFactory;
    }

    public void Run()
    {
        string input = Console.ReadLine();
        while (input != "END")
        {
            try
            {
                string[] data = input.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                string errorType = data[0];
                string dateTime = data[1];
                string message = data[2];

                IError error = this.errorFactory.CreateError(dateTime, errorType, message);
                logger.Log(error);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            input = Console.ReadLine();
        }

        Console.WriteLine($"Logger info");
        foreach (var appender in this.logger.Appenders)
        {
            Console.WriteLine($"{appender}");
        }
    }
}