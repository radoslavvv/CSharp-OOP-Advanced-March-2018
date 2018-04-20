using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Command : ICommand
{
    public Command(IList<string> args)
    {
        this.Arguments = args;
    }

    public IList<string> Arguments { get; }

    public virtual string Execute()
    {
        return null;
    }
}

