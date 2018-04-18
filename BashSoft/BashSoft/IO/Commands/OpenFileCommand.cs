﻿namespace BashSoft.IO.Commands
{
    using System;
    using System.Diagnostics;
    using Exceptions;
    using SimpleJudge;

    [Alias("open")]
    public class OpenFileCommand : Command, IExecutable
    {
        public OpenFileCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string fileName = this.Data[1];
            Process.Start(SessionData.currentPath + "\\" + fileName);
        }
    }
}
