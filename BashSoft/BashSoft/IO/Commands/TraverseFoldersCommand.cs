namespace BashSoft.IO.Commands
{
    using Exceptions;
    using SimpleJudge;

    [Alias("ls")]
    public class TraverseFoldersCommand : Command, IExecutable
    {
        [Inject]
        private IDirectoryManager iom;

        public TraverseFoldersCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            int depth = int.Parse(this.Data[1]);
            this.iom.TraverseDirectory(depth);
        }
    }
}
