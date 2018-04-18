using System;
using System.Collections.Generic;
using System.Text;

public interface IDirectoryChanger
{
    void ChangeCurrentDirectoryRelative(string realtivePath);
    void ChangeCurrentDirectoryAbsolute(string absolutePath);
}

