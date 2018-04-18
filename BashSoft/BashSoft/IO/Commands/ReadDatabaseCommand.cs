namespace BashSoft.IO.Commands
{
    using Exceptions;
    using SimpleJudge;

    [Alias("readdb")]
    public class ReadDatabaseCommand : Command, IExecutable
    {
        [Inject]
        private IDatabase repo;

        public ReadDatabaseCommand(string input, string[] data)
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
            this.repo.LoadData(fileName);
        }
    }
}
