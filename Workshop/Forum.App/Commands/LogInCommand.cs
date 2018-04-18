using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

public class LogInCommand : ICommand
{
    private IUserService userService;
    private IMenuFactory menuFactory;

    public LogInCommand(IUserService userService, IMenuFactory menuFactory)
    {
        this.userService = userService;
        this.menuFactory = menuFactory;
    }

    public IMenu Execute(params string[] args)
    {
        string username = args[0];
        string password = args[1];

        bool logingSuccess = this.userService.TryLogInUser(username, password);

        if (logingSuccess)
        {
            return this.menuFactory.CreateMenu("MainMenu");
        }

        throw new InvalidOperationException("Invalid username or password!");
    }
}

