using System;
using System.Collections.Generic;
using System.Text;

public interface IStream
{
    int Length { get; }

    int BytesSent { get; }
}
