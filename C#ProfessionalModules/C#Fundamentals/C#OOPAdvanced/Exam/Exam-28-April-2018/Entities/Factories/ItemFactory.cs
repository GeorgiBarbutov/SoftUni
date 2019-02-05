namespace Travel.Entities.Factories
{
    using Contracts;
    using Items;
    using Items.Contracts;
    using System;
    using System.Reflection;
    using Travel.Core;

    public class ItemFactory : IItemFactory
    {
        public IItem CreateItem(string type)
        {
            Assembly assembly = Assembly.GetCallingAssembly();

            Type itemType = assembly.GetType(type);

            //if(itemType == null)
            //{
            //    throw new ArgumentException(Constants.ITEM_TYPE_NOT_FOUND);
            //}
            //if(!typeof(IItem).IsAssignableFrom(itemType))
            //{
            //    throw new ArgumentException(Constants.ITEM_TYPE_NOT_ASSIGNABLE);
            //}

            IItem item = (IItem)Activator.CreateInstance(itemType);

            return item;
        }
    }
}
