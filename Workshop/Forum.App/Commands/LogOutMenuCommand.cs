using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

public class LogOutMenuCommand : ICommand
{
    private IMenuFactory menuFactory;
    private ISession session;

    public LogOutMenuCommand(IMenuFactory menuFactory, ISession session)
    {
        this.menuFactory = menuFactory;
        this.session = session;
    }

    public IMenu Execute(params string[] args)
    {
        this.session.Reset();

        return this.menuFactory.CreateMenu("MainMenu");
    }
}

