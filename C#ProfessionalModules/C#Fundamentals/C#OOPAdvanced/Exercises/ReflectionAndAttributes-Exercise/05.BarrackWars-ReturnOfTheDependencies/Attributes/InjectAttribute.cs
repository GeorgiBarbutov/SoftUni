namespace _03BarracksFactory.Core.Commands
{
    using System;

    [AttributeUsage(AttributeTargets.Field)]
    class InjectAttribute : Attribute
    {
    }
}
