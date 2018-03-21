using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerExerciese.Models
{
    public class Error : IError
    {
        public Error(DateTime dateTime, ErrorLevel errorLevel, string message)
        {
            this.DateTime = dateTime;
            this.Message = message;
            this.ErrorLevel = errorLevel;
        }

        public DateTime DateTime { get; }

        public ErrorLevel ErrorLevel { get; }

        public string Message { get; }
    }
}
