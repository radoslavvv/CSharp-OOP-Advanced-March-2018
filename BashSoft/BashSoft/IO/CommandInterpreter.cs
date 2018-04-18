namespace BashSoft
{
    using Exceptions;
    using IO.Commands;
    using SimpleJudge;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : IInterpreter
    {
        private IContentComparer judge;
        private IDatabase repository;
        private IDirectoryManager inputOutputManager;

        public CommandInterpreter(IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public void IntepredCommand(string input)
        {
            string[] data = input.Split(' ');
            string commandNane = data[0].ToLower();

            try
            {
                IExecutable command = this.ParseCommand(input, commandNane, data);
                command.Execute();
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        private IExecutable ParseCommand(string input, string command, string[] data)
        {
            object[] parametersForConstructor = new object[]
            {
                input, data
            };

            Type typeOfCommand = Assembly.GetExecutingAssembly()
                .GetTypes()
                .First(t => t.GetCustomAttributes(typeof(AliasAttribute))
                .Where(atr => atr.Equals(command))
                .ToArray().Length > 0);

            Type typeOfInterpreter = typeof(CommandInterpreter);

            Command exe = (Command)Activator.CreateInstance(typeOfCommand, parametersForConstructor);

            FieldInfo[] fieldsOfCommand = typeOfCommand
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo[] filedsOfInterpreter = typeOfInterpreter
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var fieldOfCommand in fieldsOfCommand)
            {
                Attribute atrAttribute = fieldOfCommand.GetCustomAttribute(typeof(InjectAttribute));

                if (atrAttribute != null)
                {
                    if (filedsOfInterpreter.Any(f => f.FieldType == fieldOfCommand.FieldType))
                    {
                        fieldOfCommand
                            .SetValue(exe,filedsOfInterpreter
                            .First(f => f.FieldType == fieldOfCommand.FieldType)
                            .GetValue(this));
                    }
                }
            }

            return exe;
        }
    }
}