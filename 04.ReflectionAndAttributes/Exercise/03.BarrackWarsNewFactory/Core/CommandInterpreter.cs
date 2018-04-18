using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class CommandInterpreter : ICommandInterpreter
{
    private IRepository repo;
    private IServiceProvider serviceProvider;

    public CommandInterpreter(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public IExecutable InterpretCommand(string[] data, string commandName)
    {
        Assembly assembly = Assembly.GetCallingAssembly();

        Type commandType = assembly.GetTypes().FirstOrDefault(c => c.Name.ToLower() == commandName.ToLower() + "command");

        if (commandName == null)
        {
            throw new ArgumentException("Invalid command!");
        }

        if (!typeof(IExecutable).IsAssignableFrom(commandType))
        {
            throw new ArgumentException($"{commandName} is not a command!");
        }

        //  Type type = Type.GetType($"{commandName}Command", false, true);

        var method = typeof(IExecutable).GetMethods().First();


        //var instance = commandType
        //    .GetConstructor(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public,
        //    null,
        //    new Type[] { typeof(string[]), typeof(IRepository), typeof(IUnitFactory) },
        //    null)
        //    .Invoke(new object[] { data, this.repository, this.unitFactory });

        //string result = ((Command)instance).Execute();

        FieldInfo[] fieldsToInject = commandType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(f => f.CustomAttributes.Any(c => c.AttributeType == typeof(InjectAttribute))).ToArray();

        object[] injectArgs = fieldsToInject.Select(f => this.serviceProvider.GetService(f.FieldType)).ToArray();

        var instance = Activator.CreateInstance(commandType, new object[] { data }.Concat(injectArgs).ToArray());
        return (IExecutable)instance;
    }
}

