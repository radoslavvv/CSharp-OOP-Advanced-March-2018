using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class CommandInterpreter : ICommandInterpreter
{
    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; private set; }

    public IProviderController ProviderController { get; private set; }

    public string ProcessCommand(IList<string> args)
    {
        ICommand command = this.CreateCommand(args);

        string result = command.Execute();

        return result;
    }

    private ICommand CreateCommand(IList<string> args)
    {
        string commandName = args[0];

        Type commandType = Assembly
            .GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == commandName + "Command");

        if (commandType == null)
        {
            throw new ArgumentException(string.Format(Constants.CommandNotFound, commandName));
        }

        if (!typeof(ICommand).IsAssignableFrom(commandType))
        {
            throw new InvalidOperationException(string.Format(Constants.InvalidCommand, commandName));
        }

        ConstructorInfo ctor = commandType.GetConstructors().First();
        ParameterInfo[] ctorParams = ctor.GetParameters();
        object[] parameters = new object[ctorParams.Length];

        for (int i = 0; i < parameters.Length; i++)
        {
            Type paramType = ctorParams[i].ParameterType;

            if(paramType == typeof(IList<string>))
            {
                parameters[i] = args.Skip(1).ToList();
            }
            else
            {
                PropertyInfo paramInfo = this.GetType()
                    .GetProperties()
                    .FirstOrDefault(p => p.PropertyType == paramType);

                parameters[i] = paramInfo.GetValue(this);
            }
        }
        ICommand commandInstance = (ICommand)Activator
            .CreateInstance(commandType, parameters);

        return commandInstance;
    }
}

