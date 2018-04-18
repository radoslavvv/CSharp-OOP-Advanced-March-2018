using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    private ICommandInterpreter commandInterpreter;

    public Engine(ICommandInterpreter commandInterpreter)
    {
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] data = input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            string commandName = data[0];
            IExecutable command = this.commandInterpreter.InterpretCommand(data, commandName);

            var method = typeof(IExecutable).GetMethods().First();

            try
            {
                string result = (string)method.Invoke(command, null);
                if (result != null)
                {
                    Console.WriteLine(result);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}

