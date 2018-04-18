using System;
using System.Collections.Generic;
using System.Text;

public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

public interface INameChangeable : INameable
{
    event NameChangeEventHandler NameChange;

    void OnNameChange(NameChangeEventArgs args);
}

