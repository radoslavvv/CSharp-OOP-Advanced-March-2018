using LoggerExerciese;
using LoggerExerciese.Models;
using LoggerExerciese.Models.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        ILogger logger = InitializeLogger();
        ErrorFactory errorFactory = new ErrorFactory();

        Engine engine = new Engine(logger, errorFactory);
        engine.Run();
    }

    private static ILogger InitializeLogger()
    {
        ICollection<IAppender> appenders = new List<IAppender>();

        LayoutFactory layoutFactory = new LayoutFactory();
        AppenderFactory appenderFactory = new AppenderFactory(layoutFactory);

        int appendersCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < appendersCount; i++)
        {
            string[] data = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string appenderType = data[0];
            string layoutType = data[1];
            string errorType = "INFO";

            if (data.Length > 2)
            {
                errorType = data[2];
            }

            IAppender appender = appenderFactory.CreateAppender(appenderType, errorType, layoutType);

            appenders.Add(appender);
        }

        ILogger logger = new Logger(appenders);

        return logger;
    }
}
