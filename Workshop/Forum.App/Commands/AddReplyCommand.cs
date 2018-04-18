using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;


public class AddReplyCommand : ICommand
{
    private IMenuFactory menuFactory;

    public AddReplyCommand(IMenuFactory menuFactory)
    {
        this.menuFactory = menuFactory;
    }

    public IMenu Execute(params string[] args)
    {
        string commandName = this.GetType().Name;
        string menuName = commandName.Substring(0, commandName.Length - "Command".Length) + "Menu";

        IMenu menu = this.menuFactory.CreateMenu(menuName);
        if(menu is IIdHoldingMenu idHoldinMenu)
        {
            int postId = int.Parse(args[0]);

            idHoldinMenu.SetId(postId);
        }

        return menu;
    }
}
