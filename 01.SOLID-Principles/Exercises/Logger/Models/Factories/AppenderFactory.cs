using LoggerExerciese.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerExerciese.Models.Factories
{
    public class AppenderFactory
    {
        const string DefaultFileName = "log{0}.txt";

        private LayoutFactory layoutFactory;
        private int filesNumber;

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
            this.filesNumber = 0;
        }

        public IAppender CreateAppender(string appenderType, string errorType, string layoutType)
        {
            ILayout layout = this.layoutFactory.CreateLayout(layoutType);
            ErrorLevel errorLevel = this.ParseErrorLevel(errorType);

            IAppender appender = null;
            switch (appenderType)
            {
                case "ConsoleAppender":
                    appender = new ConsoleAppender(layout, errorLevel);
                    break;
                case "FileAppender":
                    ILogFile logFile = new LogFile(string.Format(DefaultFileName, this.filesNumber));
                    appender = new FileAppender(layout, errorLevel, logFile);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidAppenderType);
            }
            return appender;
        }

        private ErrorLevel ParseErrorLevel(string errorType)
        {
            try
            {
                object errorLevelObject = Enum.Parse(typeof(ErrorLevel), errorType);

                return (ErrorLevel)errorLevelObject;
            }
            catch (ArgumentException ae)
            {
                throw new ArgumentException(ExceptionMessages.InvalidErrorLevelType, ae);
            }
        }
    }
}
