using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerExerciese.Models
{
    public class XmlLayout : ILayout
    {
        const string DateTimeFormat = "dd/MMM/yyyy h:mm:ss";

        private string Format =
              "<log>" + Environment.NewLine
            + "    <date>{0}</date>" + Environment.NewLine
            + "    <level>{1}</level>" + Environment.NewLine
            + "    <message>{2}</message>" + Environment.NewLine
            + "</log>";



        public string FormatError(IError error)
        {
            string date = error.DateTime.ToString(DateTimeFormat, CultureInfo.InvariantCulture);
            string formattedError = string.Format(Format, date, error.ErrorLevel.ToString(), error.Message);

            return formattedError;
        }
    }
}
