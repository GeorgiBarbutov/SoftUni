﻿namespace Forum.App.Factories
{
    using Forum.App.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

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
            Type menuType = assembly.GetTypes().FirstOrDefault(t => t.Name == menuName);

            if(menuType == null)
            {
                throw new ArgumentException($"Menu {menuName} not found!");
            }
            if(!typeof(IMenu).IsAssignableFrom(menuType))
            {
                throw new ArgumentException($"Menu {menuName} is not a menu!");
            }

            ParameterInfo[] parameters = menuType.GetConstructors().FirstOrDefault().GetParameters();
            object[] parametersToPass = new object[parameters.Length];

            for (int i = 0; i < parametersToPass.Length; i++)
            {
                parametersToPass[i] = this.serviceProvider.GetService(parameters[i].ParameterType);
            }

            IMenu menu = (IMenu)Activator.CreateInstance(menuType, parametersToPass);

            return menu;
        }
    }
}
