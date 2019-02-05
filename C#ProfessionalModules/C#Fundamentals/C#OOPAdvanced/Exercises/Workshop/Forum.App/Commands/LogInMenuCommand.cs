namespace Forum.App.Commands
{
    using Forum.App.Contracts;

    public class LogInMenuCommand : ICommand
    {
        private IMenuFactory menuFactory;

        public LogInMenuCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            string commandName = this.GetType().Name;
            string trimedCommandName = commandName.Substring(0, commandName.Length - "Command".Length);

            IMenu menu = menuFactory.CreateMenu(trimedCommandName);

            return menu;
        }
    }
}
