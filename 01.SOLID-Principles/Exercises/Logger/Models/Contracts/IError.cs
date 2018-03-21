using LoggerExerciese.Models.Contracts;
using System;

namespace LoggerExerciese
{
    public interface IError : ILevelable
    {
        DateTime DateTime { get; }

        string Message { get; }
    }
}