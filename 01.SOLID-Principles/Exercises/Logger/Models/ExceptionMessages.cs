using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerExerciese.Models
{
    public class ExceptionMessages
    {
        //throw new ArgumentException("Invalid Error Level Entered!", ae);
        //throw new ArgumentException("Invalid Appender Type Entered!");
        //throw new ArgumentException("Invalid Layout Type Entered!");

        public const string InvalidErrorLevelType = "Invalid Error Level Entered!";

        public const string InvalidAppenderType = "Invalid Appender Type Entered!";

        public const string InvalidLayoutType = "Invalid Layout Type Entered!";


    }
}
