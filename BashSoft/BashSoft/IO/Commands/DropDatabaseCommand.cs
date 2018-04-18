namespace BashSoft.IO.Commands
{
    using Exceptions;
    using SimpleJudge;

    [Alias("dropdb")]
    public class DropDatabaseCommand : Command, IExecutable
    {
        [Inject]
        private IDatabase repo;

        public DropDatabaseCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.repo.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }
    }
}
