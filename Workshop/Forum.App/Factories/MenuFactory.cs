using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Forum.App.Contracts;

namespace Forum.App.Factories
{
    public class MenuFactory : IMenuFactory
    {
        private IServiceProvider serviceProvider;

        public MenuFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IMenu CreateMenu(string menuName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type menuType = assembly
                .GetTypes()
                .FirstOrDefault(m => m.Name == menuName);

            if (menuType == null)
            {
                throw new InvalidOperationException($"{menuName} not found!");
            }

            if (!typeof(IMenu).IsAssignableFrom(menuType))
            {
                throw new InvalidOperationException($"{menuType} is not an IMenu!");
            }

            ConstructorInfo constructor = menuType
                .GetConstructors()
                .First();

            ParameterInfo[] ctorParams = constructor
                .GetParameters();

            object[] args = new object[ctorParams.Length];

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = this.serviceProvider.GetService(ctorParams[i].ParameterType);
            }

            IMenu menu = (IMenu)Activator.CreateInstance(menuType, args);
            //IMenu menu = (IMenu)constructor.Invoke(args);
            return menu;
        }
    }
}
