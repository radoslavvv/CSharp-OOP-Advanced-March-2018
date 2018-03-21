using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerExerciese.Models.Factories
{
    public class ErrorFactory
    {
        const string DateTimeFormat = "M/d/yyyy h:mm:ss tt";

        public IError CreateError(string dateTime, string errorType, string message)
        {
            DateTime date = DateTime.ParseExact(dateTime, DateTimeFormat, CultureInfo.InvariantCulture);
            ErrorLevel errorLevel = ParseErrorLevel(errorType);

            IError error = new Error(date, errorLevel, message);
            return error;
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
