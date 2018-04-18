using System;
using System.Collections.Generic;
using System.Text;

public class Dispatcher : INameChangeable
{
    public event NameChangeEventHandler NameChange;

    private string name;

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            NameChangeEventArgs args = new NameChangeEventArgs(value);
            OnNameChange(args);
            this.name = value;
        }
    }

    public void OnNameChange(NameChangeEventArgs args)
    {
        if(this.NameChange != null)
        {
            this.NameChange.Invoke(this, args);
        }
    }
}



