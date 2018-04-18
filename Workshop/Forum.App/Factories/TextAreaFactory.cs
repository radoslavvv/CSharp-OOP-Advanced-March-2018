﻿namespace Forum.App.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Forum.App.Models;

    public class TextAreaFactory : ITextAreaFactory
    {
        public ITextInputArea CreateTextArea(IForumReader reader, int x, int y, bool isPost = true)
        {
            //if more textareas use this |
            //                           ^
            //Assembly assembly = Assembly.GetExecutingAssembly();
            //Type commandType = assembly.GetTypes().FirstOrDefault(t => typeof(ITextInputArea).IsAssignableFrom(t));

            //if (commandType == null)
            //{
            //	throw new InvalidOperationException("TextArea not found!");
            //}

            //object[] args = new object[] { reader, x, y, isPost};

            //ITextInputArea commandInstance = (ITextInputArea)Activator.CreateInstance(commandType, args);

            ITextInputArea area = new TextInputArea(reader, x, y, isPost);
            return area;
        }
    }
}
