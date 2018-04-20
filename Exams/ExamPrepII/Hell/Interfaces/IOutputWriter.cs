﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IOutputWriter
{
    void WriteLine(string format, params string[] args);

    void WriteLine(string line);
}

