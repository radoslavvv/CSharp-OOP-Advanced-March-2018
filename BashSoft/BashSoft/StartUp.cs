namespace BashSoft
{
    using System;
    using IO.Commands;
    using SimpleJudge;

    public class StartUp
    {
        public static void Main()
        {
            IContentComparer tester = new Tester();
            IDirectoryManager ioManager = new IOManager();
            IDatabase repo = new StudentsRepository(new RepositoryFilter(), new RepositorySorter());
            IInterpreter currentInterpreter = new CommandInterpreter(tester, repo, ioManager);
            IReader reader = new InputReader(currentInterpreter);

            OutputWriter.WriteMessageOnNewLine("Please enter a coomand OR type 'help' in order to get the full list of commands which are available.");
            reader.StartReadingCommands();
        }
    }
}
