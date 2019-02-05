namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Models.Units;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type type = Type.GetType($"_03BarracksFactory.Models.Units.{unitType}");
            IUnit unit = (IUnit)Activator.CreateInstance(type);

            return unit;
        }
    }
}
