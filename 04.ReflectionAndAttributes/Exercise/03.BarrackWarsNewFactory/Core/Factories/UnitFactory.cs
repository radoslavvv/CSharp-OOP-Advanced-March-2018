namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using _03BarracksFactory.Models.Units;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = Assembly.GetCallingAssembly();

            Type type = assembly.GetTypes().FirstOrDefault((Func<Type, bool>)(u=> u.Name.ToLower() == unitType.ToLower()));

            if(type == null)
            {
                throw new ArgumentException("Invalid unit type");
            }

            if (!typeof(IUnit).IsAssignableFrom(type))
            {
                throw new ArgumentException("Invalid unit!");
            }


          //  Type type = Type.GetType($"_03BarracksFactory.Models.Units.{unitType}", false, true);

            IUnit unit = (IUnit)Activator.CreateInstance(type);

            return unit;
        }
    }
}
