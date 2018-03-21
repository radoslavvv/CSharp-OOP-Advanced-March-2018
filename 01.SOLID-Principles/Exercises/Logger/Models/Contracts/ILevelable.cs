using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerExerciese.Models.Contracts
{
    public interface ILevelable
    {
        ErrorLevel ErrorLevel { get; }
    }
}
