using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerExerciese.Models
{
    public class SimpleLayout : ILayout
    {
        const string DateTimeFormat = "M/d/yyyy h:mm:ss tt";

        const string Format = "{0} - {1} - {2}";

        public string FormatError(IError error)
        {
            string date = error.DateTime.ToString(DateTimeFormat, CultureInfo.InvariantCulture);


            string formattedError = string.Format(Format, date, error.ErrorLevel.ToString(), error.Message);

            return formattedError;
        }
    }
}
