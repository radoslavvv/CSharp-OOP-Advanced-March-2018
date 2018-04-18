namespace BashSoft.IO.Commands
{
    using Exceptions;
    using SimpleJudge;

    [Alias("cmp")]
    public class CompareFilesCommand : Command, IExecutable
    {
        [Inject]
        private IContentComparer tester;

        public CompareFilesCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);
            }

            string userOutputPath = this.Data[1];
            string expectedOutputPath = this.Data[2];
            this.tester.CompareContent(userOutputPath, expectedOutputPath);
        }
    }
}
