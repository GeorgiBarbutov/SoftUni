﻿namespace Forum.App.Commands
{
    using Contracts;

    public class ViewPostMenuCommand : ICommand
    {
        IMenuFactory menuFactory;

        public ViewPostMenuCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            int postId = int.Parse(args[0]);

            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - "Command".Length);

            IIdHoldingMenu menu = (IIdHoldingMenu)menuFactory.CreateMenu(menuName);
            menu.SetId(postId);

            return menu;
        }
    }
}
