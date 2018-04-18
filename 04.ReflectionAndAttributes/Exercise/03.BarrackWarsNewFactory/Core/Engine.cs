namespace _03BarracksFactory.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    class Engine : IRunnable
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();

                    string commandName = data[0];
                    IExecutable command = commandInterpreter.InterpretCommand(data, commandName);

                    string result = command.Execute();
                  
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        //// TODO: refactor for Problem 4
        //private string InterpredCommand(string[] data, string commandName)
        //{
        //    Assembly assembly = Assembly.GetCallingAssembly();

        //    Type commandType = assembly.GetTypes().FirstOrDefault(c => c.Name.ToLower() == commandName.ToLower() + "command");

        //    if (commandName == null)
        //    {
        //        throw new ArgumentException("Invalid command!");
        //    }

        //    if (!typeof(IExecutable).IsAssignableFrom(commandType))
        //    {
        //        throw new ArgumentException($"{commandName} is not a command!");
        //    }

        //    //  Type type = Type.GetType($"{commandName}Command", false, true);

        //    var method = typeof(IExecutable).GetMethods().First();


        //    //var instance = commandType
        //    //    .GetConstructor(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public,
        //    //    null,
        //    //    new Type[] { typeof(string[]), typeof(IRepository), typeof(IUnitFactory) },
        //    //    null)
        //    //    .Invoke(new object[] { data, this.repository, this.unitFactory });

        //    //string result = ((Command)instance).Execute();

        //    var instance = Activator.CreateInstance(commandType, new object[] { data, this.repository, this.unitFactory });

        //    string result = (string) method.Invoke(instance, null);

        //    return result;
        //}
    }
}
