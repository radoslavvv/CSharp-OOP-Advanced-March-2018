using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class AbstractCommand : ICommand
{
    public AbstractCommand(IList<string> args, IManager manager)
    {
        this.Arguments = args;
        this.Manager = manager;
    }

    public IList<string> Arguments { get; private set; }

    public IManager Manager { get; private set; }

    public abstract string Execute();
}

